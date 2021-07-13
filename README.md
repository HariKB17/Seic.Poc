# Seic.Poc
Instructions to run the Poc locally

- Setup Database and Mock data
	- Execute sql scripts from DB/DB Scripts.sql in sql server database
- Update Connection string in **Product.Service** project configuration in appsettings.json file with local database 
![image](https://user-images.githubusercontent.com/87294229/125385398-6aa16c80-e368-11eb-8ae1-b2eb68f040ca.png)
- Run both Products.Web and Products.Services project to verify the functionality

