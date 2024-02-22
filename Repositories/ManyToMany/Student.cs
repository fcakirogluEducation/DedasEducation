using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ManyToMany
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public virtual List<Teacher>? Teachers { get; set; }
    }
}