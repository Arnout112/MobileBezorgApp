using MobileBezorgApp.Models;

namespace MobileBezorgApp.Managers
{
    public class OrderManager
    {
        private List<OrderDto> _orders = new();
        private int _currentIndex = 0;

        public int CurrentIndex => _currentIndex;

        public int TotalOrdersCount() => _orders.Count;

        public OrderManager(List<OrderDto> orders)
        {
            _orders = orders;
        }

        public OrderDto GetCurrentOrder()
        {
            return _orders[_currentIndex];
        }

        public bool HasNextOrder()
        {
            return _currentIndex < _orders.Count - 1;
        }

        public void MoveToNextOrder()
        {
            if (HasNextOrder())
            {
                _currentIndex++;
            }
        }
    }
}
