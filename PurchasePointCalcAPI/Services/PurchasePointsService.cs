//using AutoMapper;
//using Contracts;

//namespace PurchasePointCalcAPI.Services
//{
//    public class PurchasePointsService : IPurchasePointsService
//    {
//        private ICustomerRepository _customerRepository;       
        

//        public PurchasePointsService( ICustomerRepository customerRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
//        {
//            _customerRepository = customerRepository;
//        }

//        public void GetAllCustomersPurchasePoints(DateTime startDate, DateTime endDate)
//        {
//            var purchases = _customerRepository.GetAllCustomersPurchases(startDate, endDate);

//            var allCustomersPoints = purchases
//                .Select(c=> new
//                { 
//                    CustomerName = c.Name,
//                    Email = c.Email,
//                    MonthlyPoints = c.Purchases
//                        .GroupBy(p => new { p.PurchaseDate.Year, p.PurchaseDate.Month})
//                        .Select(g => new {
//                            Year = g.Key.Year,
//                            Month = g.Key.Month,
//                            MonthlySum = g.Sum(p => CalculatePurchasePoints(p.TotalAmount))}),
//                    TotalPoints = c.Purchases.Sum(p => CalculatePurchasePoints(p.TotalAmount))
//                }
//                ).ToList();
//            Console.WriteLine(allCustomersPoints);
//        }
//        private int CalculatePurchasePoints(decimal totalAmount) { 
//            int points =0;

//            //Math.Floor has been used to convert to the nearest lower number
//            //Becuase we want to add a point for each dollar spent over 50 and 100.
//            int purchaseAmount =(int)Math.Floor(totalAmount);
//            if (purchaseAmount <= 50) { 
//                return points;
//            }
//            if (purchaseAmount > 50 && purchaseAmount <= 100)
//            {
//                return points = purchaseAmount - 50;
//            }
//            else { 
//                return points = purchaseAmount - 50 + purchaseAmount - 100 ;
//            }
//        }
//    }
//}
