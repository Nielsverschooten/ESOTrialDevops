import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http:HttpClient) { }
  getheaders = new HttpHeaders().set('Accept', 'application/json');
  baseUrl = "https://cloud-api-314909.ew.r.appspot.com/api/v1/"

  //items
  getItems(){
     return this.http.get<Item[]>(this.baseUrl+"items",{'headers':this.getheaders}).toPromise();
  }
  getItem(id:number){
    return this.http.get<Item>(this.baseUrl+"items"+"/"+id,{'headers':this.getheaders}).toPromise();
  }
  getWeapons(){
    return this.http.get<Item[]>(this.baseUrl+"items"+"/weapons",{'headers':this.getheaders}).toPromise();
  }
  getArmors(){
    return this.http.get<Item[]>(this.baseUrl+"items"+"/armors",{'headers':this.getheaders}).toPromise();
  }

  postArmor(item:Armor){
    return this.http.post<Armor>(this.baseUrl+"items"+"/armors",item,{'headers':this.getheaders})
  }
  postWeapon(item:Weapon){
    return this.http.post<Weapon>(this.baseUrl+"items"+"/weapons",item,{'headers':this.getheaders})
  }
  putArmor(item:Armor){
    return this.http.put<Armor>(this.baseUrl+"items"+"/armors",item,{'headers': this.getheaders})
  }
  putWeapon(item:Weapon){
    return this.http.put<Weapon>(this.baseUrl+"items"+"/weapons",item,{'headers':this.getheaders})
  }
  deleteItem(id:number){
    return this.http.delete(this.baseUrl+"items"+"/"+id,{'headers' : this.getheaders});
  }


  //player
   
  getPlayers(){
    return this.http.get<Player[]>(this.baseUrl+"players",{'headers': this.getheaders}).toPromise();
  }
  getPlayer(id:number){
    return this.http.get<Player>(this.baseUrl+"players"+"/"+id,{'headers':this.getheaders}).toPromise();
  }

  //item & player relation
  getItemsForPlayer(playerId:number){
    return this.http.get<PlayerItem[]>(this.baseUrl+"players/"+playerId+"/items",{'headers':this.getheaders})
  }
  addItemToPlayer(playerId:number,itemId:number){
    return this.http.post<PlayerItem>(this.baseUrl+"players/"+playerId+"/items/"+itemId,{'headers':this.getheaders})
  }
  RemoveItemFromPlayer(playerId:number,itemId:number){
    return this.http.delete(this.baseUrl+"players/"+playerId+"/items/"+itemId,{'headers':this.getheaders})
  }
 



  //set
  getSets(){
    return this.http.get<Set[]>(this.baseUrl+"sets",{'headers': this.getheaders}).toPromise();
  }
  //rarities
  getRarities(){
    return this.http.get<Rarity[]>(this.baseUrl+"rarities",{'headers': this.getheaders}).toPromise();
  }
  //traits
  getTraits(){
    return this.http.get<Trait[]>(this.baseUrl+"traits",{'headers': this.getheaders}).toPromise();
  }
  //enchantments
  getEnchantments(){
    return this.http.get<Enchantment[]>(this.baseUrl+"enchantments",{'headers': this.getheaders}).toPromise();
  }
}

  
export interface Player{
  id?: number;
  name: string;
  characterName: string;
  level: number;
  cp: number;
}


  export interface Trait {
      id?: number;
      name: string;
      effect: string;
  }

  export interface Rarity {
      id?: number;
      name: string;
  }

  export interface Set {
      id?: number;
      name: string;
      description: string;
  }

  export interface Enchantment {
      id?: number;
      name: string;
      effect: string;
  }

  export interface Item {
      id?: number;
      name: string;
      value: number;
      traitid: number;
      trait: Trait;
      rarityid: number;
      rarity: Rarity;
      setid: number;
      set: Set;
      enchantmentid: number;
      enchantment: Enchantment;
      item_type: string;   
  }
  export interface Weapon extends Item {
    
      damage : number;
      charge : number;
    
  }
  export interface Armor extends Item {
    armorRating:number;
    durability:number;
    armortype:string;
  }
  export interface PlayerItem{
    itemid: number;
    item: Item;
    playerid: number;
    player: Player;
}
