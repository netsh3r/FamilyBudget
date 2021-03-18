import queue
import asyncio
import aiohttp
import telebot
import requests
import json
import schedule, time
from telebot import types

from Util.Config import BOT
from Util.Keybord import get_start_btn
from Util.Keybord import auth_btn
from Util.Registration import set_login    

@BOT.message_handler(commands=['today'])
def get_position(message):
    send_messange(message)

@BOT.message_handler(commands=['start'])
def get_text_message(message):
    str = f'http://localhost:8060/api/UserApi/{message.from_user.id}'
    user = requests.get(str)
    keyboard = types.InlineKeyboardMarkup()
    if(user.text == 'null'):
        for btn in auth_btn():
            key = types.InlineKeyboardButton(text=btn["text"], callback_data=btn["callback_data"])
            keyboard.add(key)  
    
    if(user.text != 'null'):
        for btn in get_start_btn():
            key = types.InlineKeyboardButton(text=btn["text"], callback_data=btn["callback_data"])
            keyboard.add(key)        
        
    BOT.send_message(message.from_user.id, text="Список доступных действий", reply_markup=keyboard)
    # result = requests.get("http://localhost:8060/api/UserApi/1")
    # BOT.send_message(message.from_user.id, text=result.text)

@BOT.callback_query_handler(func=lambda call: True)
def callback_worker(call):
    param = call.data.split('|')
    if call.data == "registration":
        BOT.send_message(call.message.chat.id, text="Введите логин")
        BOT.register_next_step_handler(call.message,set_login)
    elif call.data == "get_budgets":
        budgets = requests.get(f"http://localhost:8060/api/BudgetApi/?tokenId={call.message.chat.id}")
        keyboard = types.InlineKeyboardMarkup()
        buttons = json.loads(budgets.text)
        for btn in buttons:
            id = str(btn["ID"])
            key = types.InlineKeyboardButton(text=id, callback_data=f"budget_id|{id}")
            keyboard.add(key)  
        BOT.send_message(call.message.chat.id, text="Список бюджетов", reply_markup=keyboard)
    elif param[0] == "budget_id":
        model = requests.get(f"http://localhost:8060/api/PositionApi/?budgetId={call.data.split('|')[1]}")
        positions = json.loads(model.text)
        for position in positions:
            BOT.send_message(call.message.chat.id, text=position["ID"])
    elif call.data == "get_position":
        send_messange()

def send_messange(message):
    # userIds = requests.get("http://localhost:8060/api/UserApi/")
    # for userId in json.loads(userIds.text):
    budgets = requests.get(f"http://localhost:8060/api/BudgetApi/?tokenId={message.from_user.id}")
    for budget in json.loads(budgets.text):
        # positions = requests.get(f"http://localhost:8060/api/PositionApi/?budgetId={budget['ID']}")
        positions = requests.get(f"http://localhost:8060/api/DatePosition/?budgetId={budget['ID']}")
        # BOT.send_message(userId, text=f"позиции по бюджету{budget['ID']}")
        for position in json.loads(positions.text):
            BOT.send_message(message.from_user.id, text=f"{position['Name']} за {position['MonthAmount']} руб.")

if __name__ == "__main__":
    BOT.polling(none_stop=False, interval=0)
       
    

    
