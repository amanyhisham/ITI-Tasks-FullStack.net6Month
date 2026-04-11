var __esDecorate = (this && this.__esDecorate) || function (ctor, descriptorIn, decorators, contextIn, initializers, extraInitializers) {
    function accept(f) { if (f !== void 0 && typeof f !== "function") throw new TypeError("Function expected"); return f; }
    var kind = contextIn.kind, key = kind === "getter" ? "get" : kind === "setter" ? "set" : "value";
    var target = !descriptorIn && ctor ? contextIn["static"] ? ctor : ctor.prototype : null;
    var descriptor = descriptorIn || (target ? Object.getOwnPropertyDescriptor(target, contextIn.name) : {});
    var _, done = false;
    for (var i = decorators.length - 1; i >= 0; i--) {
        var context = {};
        for (var p in contextIn) context[p] = p === "access" ? {} : contextIn[p];
        for (var p in contextIn.access) context.access[p] = contextIn.access[p];
        context.addInitializer = function (f) { if (done) throw new TypeError("Cannot add initializers after decoration has completed"); extraInitializers.push(accept(f || null)); };
        var result = (0, decorators[i])(kind === "accessor" ? { get: descriptor.get, set: descriptor.set } : descriptor[key], context);
        if (kind === "accessor") {
            if (result === void 0) continue;
            if (result === null || typeof result !== "object") throw new TypeError("Object expected");
            if (_ = accept(result.get)) descriptor.get = _;
            if (_ = accept(result.set)) descriptor.set = _;
            if (_ = accept(result.init)) initializers.unshift(_);
        }
        else if (_ = accept(result)) {
            if (kind === "field") initializers.unshift(_);
            else descriptor[key] = _;
        }
    }
    if (target) Object.defineProperty(target, contextIn.name, descriptor);
    done = true;
};
var __runInitializers = (this && this.__runInitializers) || function (thisArg, initializers, value) {
    var useValue = arguments.length > 2;
    for (var i = 0; i < initializers.length; i++) {
        value = useValue ? initializers[i].call(thisArg, value) : initializers[i].call(thisArg);
    }
    return useValue ? value : void 0;
};
//////////////////////////////////Question1:->Module////////////////////////////////
import { sub } from './mathfile.js';
console.log(sub(50, 10));
//////////////////////////////////Question1:->Types////////////////////////////////
let userName = "amany";
let Age = 22;
let isstudent = false;
let grades = [90, 85, 100];
let randomData = "Hello";
randomData = 25;
randomData = true;
let emptyValue = null;
let notFound = undefined;
console.log(userName, " ", Age, " ", isstudent, " ", grades, " ", randomData, " ", emptyValue, " ", notFound);
//////////////////////////////////Question1:->Union////////////////////////////////
let value;
value = "mostafa";
value = 23;
console.log(value);
//////////////////////////////////Question1:->Funcation////////////////////////////////
function sum1(num1, num2) {
    return num1 + num2;
}
console.log("Summation funcation return : ", sum1(5, 10));
function sum2(num1, num2) {
    console.log("Summation funcation void : ", num1 + num2);
}
sum2(20, 30);
//////////////////////////////////Question1:->Enum////////////////////////////////
var Days;
(function (Days) {
    Days[Days["Sat"] = 0] = "Sat";
    Days[Days["Sun"] = 1] = "Sun";
    Days[Days["Mon"] = 2] = "Mon";
    Days[Days["thurs"] = 3] = "thurs";
})(Days || (Days = {}));
let today = Days.thurs;
console.log("Today : ", today);
//////////////////////////////////Question1:->Generic////////////////////////////////
function getvalue(value) {
    return value;
}
console.log("Generic name", getvalue("amany"));
console.log("Generic Age", getvalue(22));
//////////////////////////////////////////Question1:->Decorator////////////////////////////////
function Logger(constructor) {
    console.log("Class created!");
}
let Person = (() => {
    let _classDecorators = [Logger];
    let _classDescriptor;
    let _classExtraInitializers = [];
    let _classThis;
    var Person = class {
        static { _classThis = this; }
        static {
            const _metadata = typeof Symbol === "function" && Symbol.metadata ? Object.create(null) : void 0;
            __esDecorate(null, _classDescriptor = { value: _classThis }, _classDecorators, { kind: "class", name: _classThis.name, metadata: _metadata }, null, _classExtraInitializers);
            Person = _classThis = _classDescriptor.value;
            if (_metadata) Object.defineProperty(_classThis, Symbol.metadata, { enumerable: true, configurable: true, writable: true, value: _metadata });
            __runInitializers(_classThis, _classExtraInitializers);
        }
        name = "Amany";
    };
    return Person = _classThis;
})();
////////////////////////////////////Question2:->Class2D////////////////////////////////
class Point2D {
    x;
    y;
    constructor(X, Y) {
        this.x = X;
        this.y = Y;
    }
    getDistance(p) {
        let dx = this.x - p.x;
        let dy = this.y - p.y;
        return Math.sqrt((dx * dx) + (dy * dy));
    }
}
let p1 = new Point2D(5, 3);
let p2 = new Point2D(10, 6);
console.log("Class Point2D :", p1.getDistance(p2));
///////////////////////////////////////Question3:->Class3D///////////////////////////////////
class Point3D extends Point2D {
    z;
    constructor(X, Y, Z) {
        super(X, Y); //this.x=X & this.y=Y
        this.z = Z;
    }
    getDistance(p) {
        let dx = this.x - p.x;
        let dy = this.y - p.y;
        let dz = this.z - p.z;
        return Math.sqrt((dx * dx) + (dy * dy) + (dz * dz));
    }
}
let p3 = new Point3D(3, 4, 5);
let p4 = new Point3D(15, 10, 12);
console.log("Class Point3D :", p3.getDistance(p4));
