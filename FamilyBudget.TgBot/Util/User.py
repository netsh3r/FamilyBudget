class User:
    @property
    def Login(self):
        return self.__Login

    @Login.setter
    def Login(self,Login):
        self.__Login = Login
        
    @property
    def Password(self):
        return self.__Password

    @Password.setter
    def Password(self,Password):
        self.__Password = Password
        
    @property
    def TokenID(self):
        return self.__TokenID

    @TokenID.setter
    def TokenID(self,TokenID):
        self.__TokenID = TokenID
        
    @property
    def Email(self):
        return self.__Email

    @Email.setter
    def TokenID(self,Email):
        self.__Email = Email