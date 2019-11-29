using crud.Models;
using System.Collections.Generic;

namespace crud.Interfaces
{
    /// <summary>
    /// Product Repository Interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// ListProducts Method
        /// </summary>
        /// <returns></returns>
        List<Product> ListProducts();
        
        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        Product Get(string sku);
        
        /// <summary>
        /// Add Method
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        List<Product> Add(Product product);

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        List<Product> Update(string sku, Product product);

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        List<Product> Delete(string sku);

        
    }
}
