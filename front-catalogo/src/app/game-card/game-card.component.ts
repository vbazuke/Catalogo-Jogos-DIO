import { Component, OnInit } from '@angular/core';
import { Game } from '../game';
import { GameService } from '../game.service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.css']
})
export class GameCardComponent implements OnInit {

  games: Game[] = [];

  constructor(private gameService: GameService) {}

  getGames(): void {
    this.gameService.getGames()
      .subscribe(games => this.games = games);
  }

  ngOnInit(): void {
    this.getGames();

/*     this.games = [
      { id:1,
        nome:'Diablo',
        tags:['RPG','Ação','Aventura'],
        produtora:'Blizzard',
        preco:"25,00",
        imagem:'../../assets/images/diablo.jpg',
      },
      { id:2,
        nome:'Doom III',
        tags:['FPS','Ação','Terror'],
        produtora:'ID Software',
        preco:"25,00",
        imagem:'../../assets/images/doom3.jpg',
      },
      { id:3,
        nome:'eFootball 2021',
        tags:['Esporte','Simulação'],
        produtora:'Konami',
        preco:"25,00",
        imagem:'../../assets/images/pes2021.png',
      },
      { id:4,
        nome:'World of Warcraft: Shadowlands',
        tags:['MMORPG','Aventura','Expansão'],
        produtora:'Blizzard',
        preco:"25,00",
        imagem:'../../assets/images/wow-shadowlands.jpg',
      },
      { id:5,
        nome:'Formula 1 2020',
        tags:['Corrida','Simulação'],
        produtora:'Codemasters',
        preco:"25,00",
        imagem:'../../assets/images/f12020.jpg',
      },
      { id:6,
        nome:'Among Us',
        tags:['Multiplayer','Casual','Social'],
        produtora:'InnerSloth',
        preco:"25,00",
        imagem:'../../assets/images/amongus.jpg',
      },
    ] */

  }
}
