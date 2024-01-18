import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { PrintRequest } from '@app/core/models';

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
      // .then(() => console.log('Connection started'))
      // .catch(err => console.log('Error while starting connection: ' + err));
  }

  public printLabel(request: PrintRequest) {
    this.hubConnection.invoke('PrintLabel', request);
      // .then((res: boolean) => console.log(res))
      // .catch((err) => console.log(err));
  }
}
