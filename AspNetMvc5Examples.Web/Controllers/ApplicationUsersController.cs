using AspNetMvc5Examples.Entities.DbContexts;
using AspNetMvc5Examples.Entities.IdentityManagers;
using AspNetMvc5Examples.Entities.Models;
using AspNetMvc5Examples.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db;

        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return this.roleManager ?? this.HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                this.roleManager = value;
            }
        }

        public ApplicationUsersController()
        {
            db = new ApplicationDbContext();

            // Manually create
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true
            //};
        }

        public ActionResult CreateAdministrator()
        {
            var name = this.User.Identity.Name;
            var user = this.UserManager.FindByName(name);

            //var requestAuthenticated = this.Request.IsAuthenticated;
            //var userAuthenticated = this.User.Identity.IsAuthenticated;

            if (this.User.IsInRole("Administrators"))
            {
                // TODO
            }

            if (!this.RoleManager.RoleExists("Administrators"))
            {
                var administratorRole = new IdentityRole("Administrators");
                var result = this.RoleManager.Create(administratorRole);
                //var result = this.RoleManager.Delete( administratorRole );
                if (!result.Succeeded)
                {
                    this.AddErrors(result);
                }
            }

            ApplicationUser administrator = this.UserManager.FindByName("admin@admin.com");
            if (administrator == null)
            {
                administrator = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                };

                var result = this.UserManager.Create(administrator, "admin");
                //var result = this.UserManager.Delete(administrator);
                if (!result.Succeeded)
                {
                    this.AddErrors(result);
                }
                administrator = this.UserManager.FindByName("admin@admin.com");
            }


            var roles = this.UserManager.GetRoles(administrator.Id);
            if (!roles.Contains("Administrators"))
            {
                var result = this.UserManager.AddToRole(administrator.Id, "Administrators");
                //var result = this.UserManager.RemoveFromRole(administrator.Id, "Administrators");
                if (!result.Succeeded)
                {
                    this.AddErrors(result);
                }
            }

            return new EmptyResult();
        }

        public async Task<ActionResult> SendConfirmationEmailAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                string a = this.User.Identity.GetUserId();
            }

            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
               new { userId, code }, protocol: Request.Url.Scheme);

            await UserManager.SendEmailAsync(userId,
                   "Confirm your account", "Please confirm your account by clicking <a href=\""
                   + callbackUrl + "\">here</a>");

            return new EmptyResult();
        }




        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var user = new ApplicationUser();
            user.Email = viewModel.Email;
            user.UserName = viewModel.Email;
            user.NickName = viewModel.NickName;

            //string password = System.Web.Security.Membership.GeneratePassword( 12, 4 );
            var result = await userManager.CreateAsync(user, viewModel.Password);
            //userManager.

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            this.AddErrors(result);
            return View(viewModel);
        }

        //GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        //// POST: ApplicationUsers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(ApplicationUser applicationUser )
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        db.Entry( applicationUser ).State = EntityState.Modified;
        //        db.SaveChanges( );
        //        return RedirectToAction( "Index" );
        //    }
        //    return View( applicationUser );
        //}

        // GET: ApplicationUsers/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.Users.Find(id);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationUser);
        //}

        // POST: ApplicationUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ApplicationUser applicationUser = db.Users.Find(id);
        //    db.Users.Remove(applicationUser);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
