using System;

namespace PromotionCore
{
    public interface IPromotionApply
    {
        ProductCart CalculateCartAmount(ProductCart productCart);
    }
}
