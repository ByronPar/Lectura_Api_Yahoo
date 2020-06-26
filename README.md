# LECTURA API Yahoo Weather

Lectura de longitud y latitud (localizaciones del planeta) o selección de ciudades especificas (5) para la visualización de su respectivo clima, consumiendo la API de yahoo. 

## Primeros Pasos 🚀

Dirigirse a la Pagina oficial de yahoo weather API developer https://developer.yahoo.com/weather/

Seguir pasos en la pagina descrita para crear una cuenta y automaticamente obtener sus llaves unicas y privadas para el consumo libre de la API.


### Pre-requisitos 📋

_Que cosas necesitas para ejecutar la API

```
Una petición al servicio  (en este caso utilizamos una clase)
Formato de  Salida JSON  ,XML , entre otros
Lectura correcta de Datos dependiendo el formato de Salida - En este caso utilizamos JSON)
```
Ejemplo de Salida Archivo JSON

```
{
   "location":{
      "woeid": 2502265,
      "city":"Sunnyvale",
      "region":" CA",
      "country":"United States",
      "lat":37.371609,
      "long":-122.038254,
      "timezone_id":"America/Los_Angeles"
   },
   "current_observation":{
      "wind":{
         "chill":59,
         "direction":165,
         "speed":8.7
      },
      "atmosphere":{
         "humidity":76,
         "visibility":10,
         "pressure":29.68
      },
      "astronomy":{
         "sunrise":"7:23 am",
         "sunset":"5:7 pm"
      },
      "condition":{
         "text":"Scattered Showers",
         "code":39,
         "temperature":60
      },
      "pubDate":1546992000
   },
   "forecasts":[
      {
         "day":"Tue",
         "date":1546934400,
         "low":52,
         "high":61,
         "text":"Rain",
         "code":12
      },
      {
         "day":"Wed",
         "date":1547020800,
         "low":51,
         "high":62,
         "text":"Scattered Showers",
         "code":39
      },
      {
         "day":"Thu",
         "date":1547107200,
         "low":46,
         "high":60,
         "text":"Mostly Cloudy",
         "code":28
      },
      {
         "day":"Fri",
         "date":1547193600,
         "low":48,
         "high":61,
         "text":"Showers",
         "code":11
      },
      {
         "day":"Sat",
         "date":1547280000,
         "low":47,
         "high":62,
         "text":"Rain",
         "code":12
      },
      {
         "day":"Sun",
         "date":1547366400,
         "low":48,
         "high":58,
         "text":"Rain",
         "code":12
      },
      {
         "day":"Mon",
         "date":1547452800,
         "low":47,
         "high":58,
         "text":"Rain",
         "code":12
      },
      {
         "day":"Tue",
         "date":1547539200,
         "low":46,
         "high":59,
         "text":"Scattered Showers",
         "code":39
      },
      {
         "day":"Wed",
         "date":1547625600,
         "low":49,
         "high":56,
         "text":"Rain",
         "code":12
      },
      {
         "day":"Thu",
         "date":1547712000,
         "low":49,
         "high":59,
         "text":"Scattered Showers",
         "code":39
      }
   ]
}
```

### Visualización 🔧

El Usuario debera propocionar latitud y longitud de la localidad que desee ver el clima.





## Construido con 🛠️



* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Lenguaje Utilizado
* [HTML - Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-3.1) - Fuerte tipado de Etiquetas
* [API - YAHOO](https://developer.yahoo.com/weather/documentation.html) - API consumido
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - Framework Utilizado
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/es/vs/) - IDE utilizado


## Versionado 📌

Se utiliza git como versionamiento de la aplicación en conjunto con su consola tradiciona GIT BASH, y Github como alojamiento Remoto.

## Autores ✒️

_Menciona a todos aquellos que ayudaron a levantar el proyecto desde sus inicios_

* **Byron Josué Par Rancho** - *Proyecto Completo* - [SPM Poeta - Byron Par](https://github.com/ByronPar)
* **Andrea Lopez Flores** - *Auxiliar de Laboratorio* - Resolución de dudas

## Licencia 📄

Este proyecto no contiene una licencia.

## Gracias a 🎁

* Compañeros de clase por tener una actitud positiva en todo momento  📢
* Andrea Flores por su dedicación en la calificación de distintos proyectos asi como resolución de dudas 🍺. 
* Ingeniero Ruiz por compartir de buena manera su conocimiento 🤓



---
⌨️ con ❤️ por [SPM Poeta - Byron Par] (https://github.com/ByronPar) 😊
