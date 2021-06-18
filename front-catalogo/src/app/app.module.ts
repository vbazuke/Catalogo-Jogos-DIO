import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatCardModule} from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';

import { HttpClientModule } from '@angular/common/http';

import { MainNavComponent } from './main-nav/main-nav.component';
import { GameCardComponent } from './game-card/game-card.component';
import { GameFormNewComponent } from './game-form-new/game-form-new.component';
import { GameFormUpdateComponent } from './game-form-update/game-form-update.component';
import { GameFormDeleteComponent } from './game-form-delete/game-form-delete.component';


@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    GameCardComponent,
    GameFormNewComponent,
    GameFormUpdateComponent,
    GameFormDeleteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    FlexLayoutModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
