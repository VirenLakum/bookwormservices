import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { CartService } from '../../services/cart.service';
import { Cart } from '../../poco classes/cart';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  isNavbarCollapsed = true;
  closeResult: string;
  constructor(private modalService: NgbModal, private cartService:CartService) { }

  username:string = '';
  password:string = '';
  private cartCount;
  cart: Cart[];

  ngOnInit() {
    this.reloadCart();
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = ``;
    }, (reason) => {
      this.closeResult = ``;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  reloadCart()
  {
    this.cartService.getallcategory(1).subscribe( (data)=> {
      //console.log("getting cart", this.currentUser);
      this.cart = data;
      this.cartCount = this.cart.length;
      localStorage.setItem('cartCount', this.cartCount.toString());
      this.cartCount = localStorage.getItem('cartCount');
    });
  }

}
