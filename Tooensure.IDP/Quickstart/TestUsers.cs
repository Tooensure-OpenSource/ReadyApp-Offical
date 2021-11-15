// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "@shawnDoe",
                        Password = "12345",

                        Claims = new List<Claim>
                        {
                            new Claim("given_name", "Shawn"),
                            new Claim("family_name", "Doe"),
                        }
                    },

                    new TestUser
                    {
                        SubjectId = "2",
                        Username = "@frank",
                        Password = "12345",

                        Claims = new List<Claim>
                        {
                            new Claim("given_name", "Frank"),
                            new Claim("family_name", "Joe"),
                        }
                    },
                };
            }
        }
    }
}