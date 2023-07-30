﻿using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
    }
}
