using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models.Core;
using WebApplication2.Models.EFModels;

namespace WebApplication2.Models.IRepository
{
	public interface IProductRepository
	{
		void Create(ProductEntity model);
		void Delete(int id);
		void Update(ProductEntity entity);
	}
}
