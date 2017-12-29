# HowYouSay
Xamarin.Forms unfinished port of a Swift/Java app I wrote with Ben Bishop for Rendr. This is my ongoing playground.

> This is NOT meant to be an example of amazing things that everyone (or anyone) should do. In fact, it may be the opposite. BUT you may find inspiration, and if so please run with it and make awesome stuff.

If you want to see what this app is in completed form, checkout the [original website](http://howyousayapp.com) or just go to the [App Store](https://geo.itunes.apple.com/us/app/how-you-say/id1065285274?mt=8) or [Play Store](https://play.google.com/store/apps/details?id=io.rendr.howyousay&utm_source=global_co&utm_medium=prtnr&utm_content=Mar2515&utm_campaign=PartBadge&pcampaignid=MKT-Other-global-all-co-prtnr-py-PartBadge-Mar2515-1).

![isometric](http://howusay.com/wp-content/themes/HowUSayTheme/img/bg-app-screens-isometric.png)

## Current Explorations

Xamarin.Forms CSS with SASS
- https://github.com/xamarin/Xamarin.Forms/wiki/Nightly-Builds
- [node-sass](https://github.com/sass/node-sass)

[HowYouSay/Shared/Styles/sass](https://github.com/davidortinau/HowYouSay/tree/master/HowYouSay.Shared/Styles/sass) is a nodejs project running gulp to process the scss files into css. Presently new css files must be manually added to the project and the build set to EmbeddedResource before Visual Studio can use them.

## Other Fun Herein

### Realm DB
I'd like to get this to a place where I'm using it for online/offline sync with Azure. 

### Localization
Since this is a language learning app, I took a shot at write the UI to handle localized strings from the start.


