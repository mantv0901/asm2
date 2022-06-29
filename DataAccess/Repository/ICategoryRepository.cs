using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;
using BusinessLayer.Models;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
