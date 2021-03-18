def auth_btn():
    return [{"text":"зарегистрироваться",   "callback_data":"registration"},]

def get_start_btn():
    return [{"text":"бюджеты",          "callback_data":"get_budgets"},
            {"text":"Пользователи",     "callback_data":"get_users"},]