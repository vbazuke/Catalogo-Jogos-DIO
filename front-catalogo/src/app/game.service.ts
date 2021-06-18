import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Game } from './game';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private gameUrl = '/api/v1/Jogos';  // URL to web api

  constructor(
    private http: HttpClient)
   { }

   /** GET Games from the server */
  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.gameUrl)
  }


}
