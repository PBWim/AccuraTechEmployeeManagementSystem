// Defines the root module, named AppModule, that tells Angular how to assemble the application. Initially declares only the AppComponent.
// As you add more components to the app, they must be declared here.

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
