using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new Result(true,Messages.OrderAdded);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new Result(true, Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(),Messages.OrdersListed);
        }

        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=>o.Id==orderId));
        }

        public IDataResult<List<OrderDetailDto>> GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDal.GetOrderDetails());
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new Result(true, Messages.OrderUpdated);
        }
    }
}
