"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ScannedItems = /** @class */ (function () {
    function ScannedItems() {
        this.grandTotal = 0;
        this.grandTotalDiscounted = 0;
    }
    return ScannedItems;
}());
exports.ScannedItems = ScannedItems;
var Item = /** @class */ (function () {
    function Item() {
        this.name = "";
        this.price = 0;
        this.totalItems = 0;
        this.totalItemPrice = 0;
    }
    return Item;
}());
exports.Item = Item;
//# sourceMappingURL=models.js.map