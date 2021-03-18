import json
import requests

from telebot import types
from Util.User import *

from Util.Config import BOT

def set_login(message: types.Message):
    user = User()
    user.Login = message.text
    user.TokenID = message.chat.id
    BOT.send_message(message.chat.id, text="Введите Email")
    BOT.register_next_step_handler(message,set_email,user)

def set_email(message:types.Message,user:User):
    BOT.send_message(message.chat.id, text="Введите пароль")
    BOT.register_next_step_handler(message,set_password,user)

def set_password(message:types.Message,user:User):
    user.Password = message.text
    # str = json.dumps(user.__dict__)
    model = {
        'TokenId':user.TokenID,
        'Login':user.Login,
        'Password':user.Password,
        'Email':user.Email
    }
    requests.post(f"http://localhost:8060/api/UserApi/?value={json.dumps(model)}")