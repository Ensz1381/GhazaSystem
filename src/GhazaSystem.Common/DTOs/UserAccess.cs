using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhazaSystem.Common.DTOs;

public class UserAccess
{
    public bool[] accessList { get; set; } = new bool[50];
    public Guid userId { get; set; }
}
