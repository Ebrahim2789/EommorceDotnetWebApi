using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.ProductModels
{
    public class Products
    {

        Product_Product

        Id
Name
Description

Code
Description
ShortDescription
ParentId
Price
LinePrice
CostPrice
StockEnable
Stock
OrderMinimumQuantity
OrderMaximumQuantity
Thumbnail
VideoUrl
IsPublished
SKU
Tags
IsDelete
CreateOnd
UpdateOn
    }

    public class ProductBrand
    {

        Id
        Name
Code
Description
IsPublished varchar

IsDelete
CreateOnd
UpdateOn


    }



    public class Product_Category
    {
        Id
        Name
Code
Description
ParentId
Thumbnail
DisplayOrder

IsPublished

IsDelete
CreateOnd
UpdateOn

    }





    public class Product_Media
    {

        d
        ProductId
ImageUrl
DisplayOrder
IsDelete
CreateOnd
UpdateOn


    }

    public class Product_Publish
    {


        Id
        ProductId
UserId
PublishTimeFrom
PublishTimeTo
DisplayOrder
IsDisplay
IsDelete


            }

    public class Product_OptionValue
    {

        Id
        OptionId
Value
Display
Description
IsDisplay
IsDelete
CreateOnd
UpdateOn
    }
    public class Product Option Data {

        Id
Description
OptionId
ProductId
Value Display
MediaId
IsDelete
CreateOnd
UpdateOn

    }


    public class Product_Attribute
    {
        Id
        Name
Description

IsDelete
CreateOnd
UpdateOn

}


    public class Product_AttributeValue
    {

        Id
        AttributeId
Value
Description
IsPublished
IsDelete
CreateOnd
UpdateOn

}
    public class Product_Attribute_Data
    {
        Id
        AttributeId
ProductId
Value
IsDisplay
IsDelete

}

    public class Order_Order
    {
        Id
        OrderNo
CustomerId
MerchantId
ShippingAddressId
OrderStatus
PaymentType
ShippingStatusint
ShippedOn
DeliveredOn
DeliveredEndOn
RefundStatus
RefundReason
RefundOn RefundAmount ShippingMethod PaymentMethod
PaymentFeeAmount PaymentOn PaymentEndOn SubTotal
SubTotalWithDiscount OrderTotal
DiscountAmount
OrderNote
AdminNote
CancelReason
OnHoldReason
CancelOn
CreatedById
UpdatedById
IsDelete
CreateOnd
UpdateOn

            }

    public class

Order_OrderAddress
    {
        Id
        OrderId
ContactName
PhoneNumber
AddressLine

IsDelete
CreateOnd
UpdateOn


}
    public class
Order_OrderItem
    {

        Id
        ProductId
OrderId
ProductPrice
ProductName ProductMediaUrl
Quantity
ShippedQuantity
DiscountAmount
ItemAmount
ItemWeight
Note
CreatedById
UpdatedById
IsDelete
CreateOnd
UpdateOn

    }
    public class

Reviews_Review
    {
        Id
        UserId
Title
Comment
Rating
ReviewerName
Status
EntityTypeId
EntityId
SourceId
SourceType
IsAnonymous
SupportCount
IsSystem
IsDelete
CreateOnd
UpdateOn


    }

    public class

Reviews _Reply
        {
Id
ParentId

1: customer(default value)
2: merchant
ReviewId
UserId
Comment
ReplierName ToUserId
ToUserName
Status
IsAnonymous
SupportCount

        }


public class

Reviews_ReviewMedia
{
    Id
    ReviewId
MediaId
DisplayOrder
CreateOnd
UpdateOn

        }
public class
Reviews_Support
{
    Id
    bigint
Description
UserId
EntityTypeId

EntityId
ReviewId

CreateOn
UpdateOn
}

}
