import { Component, OnInit } from '@angular/core';
import { Item, ItemService, Player, PlayerItem } from '../services/item.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {

  constructor(private itemService:ItemService) { }

  players: Player[];
  player:Player
  items:Item[] = [];
  itemsForPlayer:PlayerItem[] =[];
  itemsNotForPlayer:Item[] = [];
  selectedPlayer=1;
  ngOnInit(): void {
    this.onGetPlayers();
    this.onGetItems();
  }
  async onGetItems(){
    this.items = await this.itemService.getItems()
  }
  async onGetPlayers(){
    this.players = await this.itemService.getPlayers()
  }
  async onGetPlayer(id:number){
    this.player = await this.itemService.getPlayer(id);
  }

  RemoveItemFromPlayer(itemId:number){
    this.itemService.RemoveItemFromPlayer(this.player.id,itemId).subscribe(res=>{
      console.log(res);
      this.onGetItems();
      this.onGetItemsForPlayer();
    })
  }
  AddItemToPlayer(itemId:number){
    this.itemService.addItemToPlayer(this.player.id,itemId).subscribe(res=>{
      this.onGetItems();
      this.onGetItemsForPlayer();
    })
  }
  onGetItemsForPlayer(){
    this.itemService.getItemsForPlayer(this.player.id).subscribe(res=>{
      this.itemsForPlayer = res;
      this.itemsNotForPlayer = [];
      let ids = this.itemsForPlayer.map(pitem=>pitem.item.id);
      this.itemsNotForPlayer = this.items.filter(item=>ids.indexOf(item.id)==-1);
      console.log(this.itemsNotForPlayer)
     
    })
  }
}
