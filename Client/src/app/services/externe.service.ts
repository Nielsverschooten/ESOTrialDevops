import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExterneService {

  constructor(private http:HttpClient) { }
  private APIkey:string = "daff4de5aec00a0e757878155264d404"
  private url = "http://api.weatherstack.com"
  getCurrentWeather(location:string){
    return this.http.get<CurrentWeather>(this.url+"/current?access_key="+this.APIkey+"&query="+location).toPromise()
  }

}

export interface Request {
  type: string;
  query: string;
  language: string;
  unit: string;
}

export interface Location {
  name: string;
  country: string;
  region: string;
  lat: string;
  lon: string;
  timezone_id: string;
  localtime: string;
  localtime_epoch: number;
  utc_offset: string;
}

export interface Current {
  observation_time: string;
  temperature: number;
  weather_code: number;
  weather_icons: string[];
  weather_descriptions: string[];
  wind_speed: number;
  wind_degree: number;
  wind_dir: string;
  pressure: number;
  precip: number;
  humidity: number;
  cloudcover: number;
  feelslike: number;
  uv_index: number;
  visibility: number;
  is_day: string;
}

export interface CurrentWeather {
  request: Request;
  location: Location;
  current: Current;
}