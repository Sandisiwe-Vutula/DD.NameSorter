using DD.NameSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.NameSorter.Infrastructure.Utilities.Contract
{
    public interface INameParser
    {
        PersonName Parse(string fullName);
    }
}
