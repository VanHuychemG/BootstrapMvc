# BootstrapMvc

## Prerequisites
* https://github.com/dotnet/core/blob/master/release-notes/preview-download.md
* https://blogs.msdn.microsoft.com/dotnet/2016/10/25/announcing-net-core-1-1-preview-1/

## DONE
* bootstrap
* bootswatch
* alerts
* navigation
* bootstrap style validation
* localized form
* response cache
* static file cache
* precompiled razor views
* show/hide password (bootstrap-show-password plugin and custom)

## TODO
* login
* identity

## SETUP

install Node.js (https://github.com/nodejs/node/wiki)

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
```

