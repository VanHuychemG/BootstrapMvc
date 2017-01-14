# BootstrapMvc

## Prerequisites
* https://github.com/dotnet/core/blob/master/release-notes/preview-download.md
* https://blogs.msdn.microsoft.com/dotnet/2016/10/25/announcing-net-core-1-1-preview-1/

## DONE
* bootstrap
* bootswatch
* navigation
* response cache
* static file cache
* precompiled razor views
* identity & entity framework
* alerts
![alerts](https://raw.githubusercontent.com/VanHuychemG/BootstrapMvc/identity/BootstrapMvc.UI/wwwroot/images/alerts.png)
* bootstrap style validation
![alerts](https://raw.githubusercontent.com/VanHuychemG/BootstrapMvc/identity/BootstrapMvc.UI/wwwroot/images/bootstrap_validation.png)
* localized form
![alerts](https://raw.githubusercontent.com/VanHuychemG/BootstrapMvc/identity/BootstrapMvc.UI/wwwroot/images/localization.png)
* show/hide password (bootstrap-show-password plugin and custom)
![alerts](https://raw.githubusercontent.com/VanHuychemG/BootstrapMvc/identity/BootstrapMvc.UI/wwwroot/images/show_hide_password.png)


## TODO
* login

## SETUP

### Database

MySql

```
CREATE DATABASE `mydb` /*!40100 DEFAULT CHARACTER SET latin1 */;
CREATE USER 'dbuser'@'%' identified by 'dbpassword';
CREATE USER 'dbuser'@'localhost' identified by 'dbpassword';
GRANT ALL PRIVILEGES ON mydb.* to 'dbuser'@'%' with grant option;
GRANT ALL PRIVILEGES ON mydb.* to 'dbuser'@'localhost' with grant option;
CREATE TABLE mydb.__EFMigrationsHistory (MigrationId nvarchar(150) NOT NULL, ProductVersion nvarchar(32) NOT NULL, CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId));
```

### Tools

* Node.js
* Bower
* Gulp

### Running the project

```
npm install gulp -g

git clone https://github.com/VanHuychemG/BootstrapMvc.git

cd BootstrapMvc

dotnet restore

cd BootstrapMvc.UI

delete wwwroot/lib

bower install

npm install gulp --save-dev

gulp make-globalize-culture-nl-js

dotnet ef database update

dotnet run
```

Finally go to http://localhost:5000

