#region Using

using System.Globalization;
using CenDek.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace CenDek.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        public void CreateTestUsers()
        {

            var db = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new ApplicationUserManager(userStore);
            var username = "ryan@dissell.net";

            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = username,
                    Email = "ryan@dissell.net",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                var password = "Password123";
                var result = userManager.Create(user, password);
            }
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: /account/forgotpassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // GET: /account/login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };

            return View(viewModel);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountLoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /account/error
        [AllowAnonymous]
        public ActionResult Error()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // POST: /account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }



        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }



        // GET: /account/lock
        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }
    }
}