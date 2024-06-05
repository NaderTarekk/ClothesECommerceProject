using ClothesECommerceProject.Interfaces;
using LaptopShopECommerceProject.Models;

namespace ClothesECommerceProject.Bl
{
    public class ClsClothes : IClothes
    {
        ClothesShopContext ctx = new ClothesShopContext();
        public List<TbClothes> GetAllClothes()
        {
            try
            {
                var clothes = ctx.TbClothes.ToList();
                return clothes;
            }
            catch
            {
                return new List<TbClothes>();
            }
        }

        public TbClothes GetClothesById(int id)
        {
            try
            {
                var cloth = ctx.TbClothes.FirstOrDefault(a => a.Id == id);
                if (cloth == null)
                    return new TbClothes();
                else
                    return cloth;
            }
            catch
            {
                return new TbClothes();
            }
        }
        public List<TbClothes> RecommendedItems(int id)
        {
            try
            {
                Random rand = new Random();
                var item = GetClothesById(id);
                //var cloth = ctx.TbClothes.Where(lap => lap.Price >= item.Price - 20 && lap.Price <= item.Price + 20).ToList();
                var cloth = ctx.TbClothes.Where(c => c.Category == item.Category).ToList();
                var c = cloth.OrderBy(c => rand.Next()).Take(6).ToList();
                for (int i = 0; i < c.Count; i++)
                {
                    try
                    {
                        if (c[i].Id == item.Id)
                            c[i] = c[rand.Next(0, 11)];
                    }
                    catch
                    {
                        c[i] = c[i];
                    }
                }
                if (cloth == null)
                    return new List<TbClothes>();
                else
                    return c;
            }
            catch
            {
                return new List<TbClothes>();
            }
        }
    }
}

