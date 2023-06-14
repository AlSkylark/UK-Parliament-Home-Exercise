export interface MPEditModel {
    name: string;
    dob: Date;
    affiliationId: number;
    addressId: number;
    address1: string;
    address2?: string | null;
    town?: string | null;
    county: string;
    postcode: string;
}