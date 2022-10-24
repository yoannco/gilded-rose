import Shop from '../src/Shop';

describe('Gilded Rose', () => {

    it('Should build', () => {
        let shop = new Shop();
        expect(shop).toBeInstanceOf(Shop);
    });

});
