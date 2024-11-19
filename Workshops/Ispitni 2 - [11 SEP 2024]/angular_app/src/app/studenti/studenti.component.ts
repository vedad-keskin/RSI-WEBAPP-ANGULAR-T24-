import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;

  novi_student:any;
  opstine:any;
  edit_student:any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();
    this.GetAllOpstine();
  }

  FiltirirajStudente() {

    if(this.ime_prezime == "" && this.opstina == ""){
      return this.studentPodaci;
    }

    return this.studentPodaci.filter((x:any) =>

      (!this.filter_ime_prezime || (x.ime + " " + x.prezime).toLowerCase().startsWith(this.ime_prezime.toLowerCase())  || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.ime_prezime.toLowerCase())   )
      &&
      (!this.filter_opstina || x.opstina_rodjenja.description.toLowerCase().startsWith(this.opstina.toLowerCase()) )

    );



  }

  NoviStudent() {

    this.novi_student = {

      // ime: this.ime_prezime,
      ime: this.ime_prezime.charAt(0).toUpperCase() + this.ime_prezime.slice(1) ,
      prezime: "",
      opstina_rodjenja_id : 4
      // opstina_rodjenja_id: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.defaultOpstinaId

    }


  }

  private GetAllOpstine() {


    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAllOpstine", MojConfig.http_opcije()).subscribe(x=>{
      this.opstine = x;
    });

  }

  SpasiStudent() {


    this.httpKlijent.post(MojConfig.adresa_servera + "/DodajStudent", this.novi_student, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit(); // refresh podataka
        this.novi_student = null // zatvoriti modal da ne bude otvoren bezveze

        porukaSuccess("Student uspješno dodan");
      } ,error => {

        porukaError("Student nije uspješno dodan");

      });



  }

  EditujStudenta() {


    this.httpKlijent.post(MojConfig.adresa_servera + "/DodajStudent", this.edit_student, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit(); // refresh podataka
        this.edit_student = null // zatvoriti modal da ne bude otvoren bezveze

        porukaSuccess("Student uspješno editovan");
      } ,error => {

        porukaError("Student nije uspješno editovan");

      });

  }

  ObrisiStudenta(id:any) {

    this.httpKlijent.post(MojConfig.adresa_servera + "/ObrisiStudent", id, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit(); // refresh podataka


        porukaSuccess("Student uspješno obrisan");
      } ,error => {

        porukaError("Student nije uspješno obrisan");

      });

  }



}
