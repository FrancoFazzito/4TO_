using System;
using System.Collections.Generic;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
    public class OrderBusiness : AbstractBussiness
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        OrderDAC orderDAC = new OrderDAC();
        OrderNumberDAC orderNumberDAC = new OrderNumberDAC();
        OrderDetailDAC orderDetailDAC = new OrderDetailDAC();
    
        ClientBusiness clientBusiness = new ClientBusiness();
        ProductBusiness productBusiness = new ProductBusiness();
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Order Save(Order dto)
        {
            Order update;
            bool needOrderNumber = false;
            if (dto.Id > 0)
                update = orderDAC.FindById<Order>(dto.Id);
            else
            {
                update = new Order {CreatedOn = DateTime.Now, CreatedBy = dto.CreatedBy, Rowid = Guid.NewGuid()};
                needOrderNumber = true;
            }

            if (dto.ClientId <= 0)
            {
                throw new BusinessException("b.validation.order.clientId.invalid");
            }
            if (clientBusiness.Find(dto.ClientId) == null)
            {
                throw new BusinessException("b.validation.order.clientId.missing");                
            }

            update.ClientId = dto.ClientId;
            
            update.State = dto.State < 0 ? throw new BusinessException("b.validation.order.productId.missing") : dto.State;

            update.OrderDate = dto.OrderDate;
            
            update.ChangedOn = DateTime.Now;
            update.ChangedBy = dto.ChangedBy;
            var saved = orderDAC.Save(update);

            if (needOrderNumber)
            {
                OrderNumber number = new OrderNumber();
                number.CreatedBy = update.CreatedBy;
                number.CreatedOn = update.CreatedOn;
                number.ChangedBy = update.ChangedBy;
                number.ChangedOn = update.ChangedOn;

                number.Number = saved.Id;

                number = orderNumberDAC.Save(number);

                saved.OrderNumber = number.Number;

                saved = orderDAC.Save(update);

            }
            
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            orderDAC.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> All()
        {

            var result = orderDAC.SelectAll();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order Find(int id)
        {
            return orderDAC.SelectById(id);

        }


        public OrderDetail AddOrderDetail(OrderDetail detail)
        {

            if (Find(detail.OrderId) == null)
            {
                throw new BusinessException("b.validation.orderdetail.orderid.missing");                

            }
            
            var saved = orderDetailDAC.Save(detail);

            return saved;
        }

        public void RemoveOrderDetail(int orderId, int orderDetailId)
        {
            var detail = orderDetailDAC.FindById<OrderDetail>(orderDetailId);

            if (detail != null && detail.OrderId == orderId)
            {
                orderDetailDAC.DeleteById(orderDetailId);
            }
            else
            {
                logger.Warn($"Se intento eliminar un detalle de orden que no correspondia con la orden actual: orderId {orderId} - order detail id {orderDetailId}");
            }
            
        }

    }
}