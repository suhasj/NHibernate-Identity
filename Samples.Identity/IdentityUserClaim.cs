﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Identity
{
    public class IdentityUserClaim
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// User Id for the user who owns this login
        /// </summary>
        public virtual int UserId { get; set; }

        /// <summary>
        /// Claim type
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Claim value
        /// </summary>
        public virtual string ClaimValue { get; set; }
    }
}
