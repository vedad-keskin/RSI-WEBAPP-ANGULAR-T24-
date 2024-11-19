import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  novi_upis:any;
  studentID:any;
  student:any;

  upisi:any;
  akademskeGodine:any;
  ovjera_upis:any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {

    this.route.params.subscribe(params => {
      this.studentID = params['id'];
    })

  }





  ngOnInit(): void {

    this.GetStudent();
    this.GetUpisiStudenta();
    this.GetAkademskeGodine();
  }

  private GetStudent() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetStudent" , {

      headers: {
        "autentifikacija-token" : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },


       params:{studentid:this.studentID},
       observe: 'response',
    }  ).subscribe(response=>{

      this.student = response.body;

    });

  }


  private GetUpisiStudenta() {

    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetUpisiStudenta" , {

      headers: {
        "autentifikacija-token" : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.vrijednost
      },

      params:{studentid:this.studentID},
      observe: 'response',
    }  ).subscribe(response=>{

      this.upisi = response.body;

    });


  }

  NoviUpis() {

    this.novi_upis = {

      studentid : this.studentID,
      evidentiraoid : AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      datumUpis: new Date().toISOString().split('T')[0]


    }


  }

  private GetAkademskeGodine() {


    this.httpKlijent.get(MojConfig.adresa_servera+ "/GetAllAkademske", MojConfig.http_opcije()).subscribe(x=>{
      this.akademskeGodine = x;
    });


  }

  SpasiUpis() {


    this.httpKlijent.post(MojConfig.adresa_servera + "/DodajUpis", this.novi_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit(); // refresh podataka
        this.novi_upis = null // zatvoriti modal da ne bude otvoren bezveze

        porukaSuccess("Upis uspješno dodan");
      } ,error => {

        porukaError("Upis nije uspješno dodan zato sto se kliknuli da nije obnova a vec imate tu godinu dodatu");

      });

  }

  OvjeriUpis() {

    this.httpKlijent.post(MojConfig.adresa_servera + "/OvjeriUpis", this.ovjera_upis, MojConfig.http_opcije())
      .subscribe((x: any) => {

        this.ngOnInit(); // refresh podataka
        this.ovjera_upis = null // zatvoriti modal da ne bude otvoren bezveze

        porukaSuccess("Upis uspješno ovjeren");
      } ,error => {

        porukaError("Upis nije uspješno ovjeren");

      });


  }


  IzracunajObnovu($event: any) {

    const godinaStudija : number = parseInt($event, 10);

    if(this.upisi.some((x:any) => x.godinaStudija == godinaStudija )){
      this.novi_upis.cijenaSkolarine = 400;
      this.novi_upis.obnova = true;
    }else{
      this.novi_upis.cijenaSkolarine = 1800;
      this.novi_upis.obnova = false;
    }


  }
}
