import React, { useEffect, useState } from 'react';
import axios from 'axios';

const OrderList = () => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        axios.get('/api/orders')
            .then(response => setOrders(response.data))
            .catch(error => console.error(error));
    }, []);

    return (
        <div>
            <h2>Список заказов</h2>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Город отправителя</th>
                        <th>Адрес отправителя</th>
                        <th>Город получателя</th>
                        <th>Адрес получателя</th>
                        <th>Вес груза (кг)</th>
                        <th>Дата забора груза</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.map(order => (
                        <tr key={order.id}>
                            <td>{order.id}</td>
                            <td>{order.senderCity}</td>
                            <td>{order.senderAddress}</td>
                            <td>{order.receiverCity}</td>
                            <td>{order.receiverAddress}</td>
                            <td>{order.weight}</td>
                            <td>{new Date(order.pickupDate).toLocaleDateString()}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default OrderList;