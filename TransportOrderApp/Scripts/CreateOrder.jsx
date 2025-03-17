import React, { useState } from 'react';
import axios from 'axios';

const CreateOrder = () => {
    const [order, setOrder] = useState({
        senderCity: '',
        senderAddress: '',
        receiverCity: '',
        receiverAddress: '',
        weight: 0,
        pickupDate: ''
    });

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('/api/orders', order)
            .then(response => {
                alert('Заказ создан!');
                window.location.reload(); // Обновить страницу
            })
            .catch(error => console.error(error));
    };

    return (
        <div>
            <h2>Создание нового заказа</h2>
            <form onSubmit={handleSubmit}>
                <label>
                    Город отправителя:
                    <input
                        type="text"
                        value={order.senderCity}
                        onChange={(e) => setOrder({ ...order, senderCity: e.target.value })}
                    />
                </label>
                <label>
                    Адрес отправителя:
                    <input
                        type="text"
                        value={order.senderAddress}
                        onChange={(e) => setOrder({ ...order, senderAddress: e.target.value })}
                    />
                </label>
                <label>
                    Город получателя:
                    <input
                        type="text"
                        value={order.receiverCity}
                        onChange={(e) => setOrder({ ...order, receiverCity: e.target.value })}
                    />
                </label>
                <label>
                    Адрес получателя:
                    <input
                        type="text"
                        value={order.receiverAddress}
                        onChange={(e) => setOrder({ ...order, receiverAddress: e.target.value })}
                    />
                </label>
                <label>
                    Вес груза (кг):
                    <input
                        type="number"
                        value={order.weight}
                        onChange={(e) => setOrder({ ...order, weight: parseFloat(e.target.value) })}
                    />
                </label>
                <label>
                    Дата забора груза:
                    <input
                        type="date"
                        value={order.pickupDate}
                        onChange={(e) => setOrder({ ...order, pickupDate: e.target.value })}
                    />
                </label>
                <button type="submit">Создать</button>
            </form>
        </div>
    );
};

export default CreateOrder;