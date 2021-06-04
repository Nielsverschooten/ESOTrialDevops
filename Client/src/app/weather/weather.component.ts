import { Component, OnInit } from '@angular/core';
import { CurrentWeather, ExterneService } from '../services/externe.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  constructor(private weatherService:ExterneService) { }
  location
  weather:CurrentWeather
  async getCurrentWeather(){
    console.log(this.weather = await this.weatherService.getCurrentWeather(this.location));
  }
  ngOnInit(): void {
  }

}
