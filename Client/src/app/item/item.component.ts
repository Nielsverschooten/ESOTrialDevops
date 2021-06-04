import { Component, OnInit } from '@angular/core';
import { Armor,Weapon,Set,Trait,Enchantment,Rarity, Item, ItemService } from '../services/item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  constructor(private itemService:ItemService) { }

  ngOnInit(): void {
     this.onGetItems();
     this.onGetRarities();
     this.onGetSets();
     this.onGetTraits();
     this.onGetEnchantments();
  }
  addArmor:Armor ={
    name: null,
      value: null,
      traitid: null,
      trait: null,
      rarityid: null,
      rarity: null,
      setid: null,
      set: null,
      enchantmentid: null,
      enchantment: null,
      item_type: "armor",
      durability:null,
      armorRating:null,
      armortype:null  
  };
  addWeapon:Weapon = {
    damage:null,
    charge:null,
    name: null,
      value: null,
      traitid: null,
      trait: null,
      rarityid: null,
      rarity: null,
      setid: null,
      set: null,
      enchantmentid: null,
      enchantment: null,
      item_type: "weapon",

  };
  shownitems:boolean = false;
  selectedTrait =1;
  selectedSet;
  selectedRarity;
  selectedEnchantment;
  items:Item[];
  weapons:Item[];
  armors:Item[];
  sets:Set[];
  rarities:Rarity[];
  traits:Trait[];
  enchantments:Enchantment[];
  armorHeaders = ["num","name","value","trait","rarity","set","enchantment","armor type","armor rating", "durability"]
  weaponHeaders = ["num","name","value","trait","rarity","set","enchantment","damage","charge"]

  enableEditDelete = 0
  enableEditIndex = null;

  enableEditMethod(e, i) {
    this.enableEditDelete = 1;
    this.enableEditIndex = i;
  }
  enableDeleteMethod(e,i){
    this.enableEditDelete = 2;
    this.enableEditIndex =i;
  }
 

  async onGetItems(){
   this.items = await this.itemService.getItems()
   console.log(this.items)
   this.onGetWeapons()
   this.onGetArmors()
  }
  async onGetItem(id:number){
    return this.itemService.getItem(id)
   
  }
  async onGetSets(){
    this.sets = await this.itemService.getSets()
  }
  async onGetTraits(){
    this.traits = await this.itemService.getTraits()
  }
  async onGetRarities(){
    this.rarities = await this.itemService.getRarities()
  }
  async onGetEnchantments(){
    this.enchantments = await this.itemService.getEnchantments()
  }
  async onGetWeapons(){
    this.weapons = await this.itemService.getWeapons()
  }
  async onGetArmors(){
    this.armors = await this.itemService.getArmors()
  }

  onPostArmor(name:string,value:number,traidid:number,rarityid:number,setid:number,enchantmentid:number,durability:number,armorRating:number,armortype:string){
    
    let armor:Armor = {
    name:name,
    value:value,
    traitid:traidid,
    trait:null,
    enchantmentid:enchantmentid,
    enchantment:null,
    rarityid:rarityid,
    rarity:null,
    setid:setid,
    set:null,
    item_type:"armor",
    armorRating:armorRating,
    armortype:armortype,
    durability:durability
    }
    
    this.itemService.postArmor(armor).subscribe(res =>{
      console.log(res);
      this.onGetArmors();
      this.onGetItems();
      this.addArmor ={
        name: null,
          value: null,
          traitid: null,
          trait: null,
          rarityid: null,
          rarity: null,
          setid: null,
          set: null,
          enchantmentid: null,
          enchantment: null,
          item_type: "armor",
          durability:null,
          armorRating:null,
          armortype:null  
      };
    })
   }
  onPostWeapon(name:string,value:number,traidid:number,rarityid:number,setid:number,enchantmentid:number,damage:number, charge:number){
    
    let weapon:Weapon = {
    name:name,
    value:value,
    traitid:traidid,
    trait:null,
    enchantmentid:enchantmentid,
    enchantment:null,
    rarityid:rarityid,
    rarity:null,
    setid:setid,
    set:null,
    item_type:"weapon",
    damage:damage,
    charge:charge
    }
    
    this.itemService.postWeapon(weapon).subscribe(res =>{
      console.log(res);
      this.onGetItems();
      this.onGetWeapons();
      this.addWeapon = {
        damage:null,
        charge:null,
        name: null,
          value: null,
          traitid: null,
          trait: null,
          rarityid: null,
          rarity: null,
          setid: null,
          set: null,
          enchantmentid: null,
          enchantment: null,
          item_type: "weapon",
    
      };
    })
   }
   onPutArmor(id:number,name:string,value:number,traidid:number,rarityid:number,setid:number,enchantmentid:number,durability:number,armorRating:number,armortype:string){
    let armor:Armor = {
      id:id,
      name:name,
      value:value,
      traitid:traidid,
      trait:null,
      enchantmentid:enchantmentid,
      enchantment:null,
      rarityid:rarityid,
      rarity:null,
      setid:setid,
      set:null,
      item_type:"armor",
      armorRating:armorRating,
      armortype:armortype,
      durability:durability
      }

      this.itemService.putArmor(armor).subscribe(res =>{
        console.log(res);
        this.enableEditDelete = 0;
        this.enableEditIndex = null;
        this.onGetItems();
      })
   }
   onPutWeapon(id:number,name:string,value:number,traidid:number,rarityid:number,setid:number,enchantmentid:number,damage:number, charge:number){
    
    let weapon:Weapon = {
    id:id,
    name:name,
    value:value,
    traitid:traidid,
    trait:null,
    enchantmentid:enchantmentid,
    enchantment:null,
    rarityid:rarityid,
    rarity:null,
    setid:setid,
    set:null,
    item_type:"weapon",
    damage:damage,
    charge:charge
    }
    
    this.itemService.putWeapon(weapon).subscribe(res =>{
      console.log(res);
      this.enableEditDelete = 0;
        this.enableEditIndex = null;
      this.onGetItems();
    })
   }
   onDeleteItem(id:number){
     this.itemService.deleteItem(id).subscribe(res=>{
       console.log(res);
       this.onGetItems();
       this.enableEditDelete = 0;
    this.enableEditIndex =null;
     })
   }
}
