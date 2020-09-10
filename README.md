# Online Clothing Shop

![](Images/main-page.gif)


**An application that performs the basic functions of an online shop:**

  - Login and register new users.
  - Editing user account (change/reset password,  change user name and address)
  - CRUD of products (inluding images uploading).
  - Searching products, filtering and sorting results.
  - Session-based shopping cart.
  - Saving favourites products.
  - Orders.
  - User’s purchase history.
  - Admin panel.
  - List of all transactions in admin panel and ability to change their status.
  - Sending email-confirmation, order-summary and password-reset emails.
  - Confirmation popups.
  - Product archive.

## Technologies

- ASP.NET Core 3.1 MVC
- Entity Framework
- Identity
- SendGrid
- SweetAlert 2
- AJAX

## Configuration
...
...


## Demonstration of functionality



### Administrator panel:

#### 1. Adding new product.

![](Images/add-product.gif)

#### 2. Editing existing product.

As you can see on the gif below edit form allows to change data like name, description etc. Administrator can also add or remove products of the given size and lower the price. As a result new sizes, the old price, the new price and the discount can be seen additionally.

![](Images/edit-product.gif) 

#### 1. Archiving and restoring products.

![](Images/archive.gif)



### Other users:

#### 1. New user registration.

![](Images/register.gif) 

#### 2. Email confirmation.

![](Images/email-confirmation.gif)

#### 3. Login to the created account.

![](Images/login.gif)

#### 3. Reset password when forgot.

![](Images/reset-password.gif)

#### 5. Editing user data.

![](Images/edit-user.gif)

#### 6. Adding and removing favourite product.

![](Images/add-remove-favourites.gif) 



### Common features: 

#### 1. Searching, filtering, sorting.

![](Images/searching-filtering-sorting.gif)



### Buying process:

#### 1. Adding and removing products from cart.

![](Images/add-remove-cart.gif) 

### 2. Finalization of purchases.

![](Images/purchase-finalization.gif) 

After making a purchase, the user receives an email with a summary

![](Images/order-summary-email.jpg)

### 3. Change of order status by admin when it is ready to send.

![](Images/change-of-order-status.gif)


















