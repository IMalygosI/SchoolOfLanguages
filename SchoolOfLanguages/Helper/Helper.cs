using Microsoft.EntityFrameworkCore.Storage;
using SchoolOfLanguages.Context;
using SchoolOfLanguages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOfLanguages
{
    public class Helper
    {
        public static readonly DimaBaseContext DataBase = new DimaBaseContext(); // Заменил " User738Context " НА " DimaBaseContext "


    }
}