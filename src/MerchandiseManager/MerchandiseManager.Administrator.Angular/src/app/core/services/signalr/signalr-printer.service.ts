import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRPrinterService {

  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:12669/hubs/label-printer')
      .build();

    return this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public printLabel = () => {
    // tslint:disable-next-line: max-line-length
    this.hubConnection
      .invoke('PrintLabel', { labelsCount: 1, barcodeToPrint: 'M123123', printingProduct: { productName: 'Крючок', price: 10 } })
      .then((res) => console.log(res));
  }
}
