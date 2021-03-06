﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GlanceBudgeter.Models.Helpers
{
    public class AuthorizeHouseHoldRequired : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            return httpContext.User.Identity.IsInHouseHold();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "Home", action = "CreateJoinHouseHold" }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                (new { controller = "Home", action = "UnauthorizedIndex" }));
                //base.HandleUnauthorizedRequest(filterContext);
            }

        }
    }

}