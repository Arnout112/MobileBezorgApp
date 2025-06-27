using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBezorgApp.Managers
{
    public class OrderManager
    {
        private List<int> _orderIds;
        private int _currentIndex = 0;

        public OrderManager(List<int> orderIds)
        {
            _orderIds = orderIds;
        }

        public int GetCurrentOrderId()
        {
            return _orderIds[_currentIndex];
        }

        public bool HasNextOrder()
        {
            return _currentIndex < _orderIds.Count - 1;
        }

        public void MoveToNextOrder()
        {
            if (HasNextOrder())
                _currentIndex++;
        }
    }

}
