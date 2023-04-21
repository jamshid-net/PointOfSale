using Dapper;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Models
{
    
    public class ProductsRepo: IProductRepository
    {
        private readonly string _connection;
        public ProductsRepo()
        {
            _connection = GetConnection.Connection();
        }
       

        public async Task<bool> DeleteByIdAsync(int ProductId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {

                await conn.OpenAsync();

                string cmdText = @"Delete from products where product_id = @id;";
                if (await conn.ExecuteAsync(cmdText, new { id = ProductId }) > 0) return true;
                else return false;
            }
            
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<Product> products = new List<Product>();   
                await conn.OpenAsync();
                string cmdText = @"select * from products;";
                 var reader = await  conn.ExecuteReaderAsync(cmdText);
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Category = await new CategoryRepo().GetByIdAsync(reader.GetInt32(1)),
                        ProductName = reader.GetString(2),
                        ProductPrice = reader.GetDecimal(3),
                        ProductDescription = reader.GetString(4),
                        ProductPicture = reader.GetString(5)

                    }) ;
                }

                return products;
            }
        }
        
        public async Task<Product> GetByIdAsync(int productId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                
                await conn.OpenAsync();
                string cmdText = @"select * from products where product_id = @id;";
                var reader = await conn.ExecuteReaderAsync(cmdText, new { id = productId });
                Product product = new();
                while (reader.Read())
                {
                    product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Category = await new CategoryRepo().GetByIdAsync(reader.GetInt32(1)),
                        ProductName = reader.GetString(2),
                        ProductPrice = reader.GetDecimal(3),
                        ProductDescription = reader.GetString(4),
                        ProductPicture = reader.GetString(5)

                    };
                }
               
               
                return product;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"INSERT INTO products(category_id, product_name,
                                  product_price, 
                                  product_description, 
                                  product_picture)
	                              VALUES (@CategoryId,@ProductName, 
                                  @ProductPrice, @ProductDescription, @ProductPicture);";
                if (await conn.ExecuteAsync(cmdText,
                    new
                    {
                        CategoryId = product.Category.CategoryID,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductDescription = product.ProductDescription,
                        ProductPicture = product.ProductPicture

                    }) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using(NpgsqlConnection conn=new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @" update products set 
                                    category_id=@CategoryId,
                                    product_name=@ProductName,
                                    product_price=@ProductPrice,
                                    product_description=@ProductDescription,
                                    product_picture = @ProductPicture
                                    where product_id = @ProductId;";
                if (await conn.ExecuteAsync(cmdText,
                     new
                     {
                         ProductId = product.ProductId,
                         CategoryId = product.Category.CategoryID,
                         ProductName = product.ProductName,
                         ProductPrice = product.ProductPrice,
                         ProductDescription = product.ProductDescription,
                         ProductPicture = product.ProductPicture

                     }) > 0) return true;
                else return false;

            }
        }
        
        public async Task<List<Product>> GetAllGroupCategoryAsync(int categoryId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {

                await conn.OpenAsync();
                string cmdText = @"select * from products 
                                   where category_id = @id;";
                var reader = await conn.ExecuteReaderAsync(cmdText, new { id = categoryId });
                List<Product> products = new();
                while (await reader.ReadAsync())
                {
                    products.Add(new Product
                    {
                        ProductId = reader.GetInt32(0),
                        Category = await new CategoryRepo().GetByIdAsync(reader.GetInt32(1)),
                        ProductName = reader.GetString(2),
                        ProductPrice = reader.GetDecimal(3),
                        ProductDescription = reader.GetString(4),
                        ProductPicture = reader.GetString(5)

                    });
                }


                return products;
            }
        }
    }
}
