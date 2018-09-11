﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eron.Business.Core.Connected_Services.ZarinPalService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://zarinpal.com/", ConfigurationName="ZarinPalService.PaymentGatewayImplementationServicePortType")]
    public interface PaymentGatewayImplementationServicePortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequest", ReplyAction="*")]
        PaymentRequestResponse PaymentRequest(PaymentRequestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<PaymentRequestResponse> PaymentRequestAsync(PaymentRequestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequestWithExtra", ReplyAction="*")]
        PaymentRequestWithExtraResponse PaymentRequestWithExtra(PaymentRequestWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentRequestWithExtra", ReplyAction="*")]
        System.Threading.Tasks.Task<PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(PaymentRequestWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerification", ReplyAction="*")]
        PaymentVerificationResponse PaymentVerification(PaymentVerificationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerification", ReplyAction="*")]
        System.Threading.Tasks.Task<PaymentVerificationResponse> PaymentVerificationAsync(PaymentVerificationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerificationWithExtra", ReplyAction="*")]
        PaymentVerificationWithExtraResponse PaymentVerificationWithExtra(PaymentVerificationWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#PaymentVerificationWithExtra", ReplyAction="*")]
        System.Threading.Tasks.Task<PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(PaymentVerificationWithExtraRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#GetUnverifiedTransactions", ReplyAction="*")]
        GetUnverifiedTransactionsResponse GetUnverifiedTransactions(GetUnverifiedTransactionsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#GetUnverifiedTransactions", ReplyAction="*")]
        System.Threading.Tasks.Task<GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(GetUnverifiedTransactionsRequest request);
        
        // CODEGEN: Generating message contract since element name MerchantID from namespace http://zarinpal.com/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="#RefreshAuthority", ReplyAction="*")]
        RefreshAuthorityResponse RefreshAuthority(RefreshAuthorityRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#RefreshAuthority", ReplyAction="*")]
        System.Threading.Tasks.Task<RefreshAuthorityResponse> RefreshAuthorityAsync(RefreshAuthorityRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequest", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentRequestRequestBody Body;
        
        public PaymentRequestRequest() {
        }
        
        public PaymentRequestRequest(PaymentRequestRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Amount;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Description;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Mobile;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string CallbackURL;
        
        public PaymentRequestRequestBody() {
        }
        
        public PaymentRequestRequestBody(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL) {
            this.MerchantID = MerchantID;
            this.Amount = Amount;
            this.Description = Description;
            this.Email = Email;
            this.Mobile = Mobile;
            this.CallbackURL = CallbackURL;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequestResponse", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentRequestResponseBody Body;
        
        public PaymentRequestResponse() {
        }
        
        public PaymentRequestResponse(PaymentRequestResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        public PaymentRequestResponseBody() {
        }
        
        public PaymentRequestResponseBody(int Status, string Authority) {
            this.Status = Status;
            this.Authority = Authority;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestWithExtraRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequestWithExtra", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentRequestWithExtraRequestBody Body;
        
        public PaymentRequestWithExtraRequest() {
        }
        
        public PaymentRequestWithExtraRequest(PaymentRequestWithExtraRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestWithExtraRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Amount;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Description;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string AdditionalData;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Email;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string Mobile;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string CallbackURL;
        
        public PaymentRequestWithExtraRequestBody() {
        }
        
        public PaymentRequestWithExtraRequestBody(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL) {
            this.MerchantID = MerchantID;
            this.Amount = Amount;
            this.Description = Description;
            this.AdditionalData = AdditionalData;
            this.Email = Email;
            this.Mobile = Mobile;
            this.CallbackURL = CallbackURL;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequestWithExtraResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequestWithExtraResponse", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentRequestWithExtraResponseBody Body;
        
        public PaymentRequestWithExtraResponse() {
        }
        
        public PaymentRequestWithExtraResponse(PaymentRequestWithExtraResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentRequestWithExtraResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        public PaymentRequestWithExtraResponseBody() {
        }
        
        public PaymentRequestWithExtraResponseBody(int Status, string Authority) {
            this.Status = Status;
            this.Authority = Authority;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerification", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentVerificationRequestBody Body;
        
        public PaymentVerificationRequest() {
        }
        
        public PaymentVerificationRequest(PaymentVerificationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Amount;
        
        public PaymentVerificationRequestBody() {
        }
        
        public PaymentVerificationRequestBody(string MerchantID, string Authority, int Amount) {
            this.MerchantID = MerchantID;
            this.Authority = Authority;
            this.Amount = Amount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerificationResponse", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentVerificationResponseBody Body;
        
        public PaymentVerificationResponse() {
        }
        
        public PaymentVerificationResponse(PaymentVerificationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public long RefID;
        
        public PaymentVerificationResponseBody() {
        }
        
        public PaymentVerificationResponseBody(int Status, long RefID) {
            this.Status = Status;
            this.RefID = RefID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationWithExtraRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerificationWithExtra", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentVerificationWithExtraRequestBody Body;
        
        public PaymentVerificationWithExtraRequest() {
        }
        
        public PaymentVerificationWithExtraRequest(PaymentVerificationWithExtraRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationWithExtraRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int Amount;
        
        public PaymentVerificationWithExtraRequestBody() {
        }
        
        public PaymentVerificationWithExtraRequestBody(string MerchantID, string Authority, int Amount) {
            this.MerchantID = MerchantID;
            this.Authority = Authority;
            this.Amount = Amount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentVerificationWithExtraResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentVerificationWithExtraResponse", Namespace="http://zarinpal.com/", Order=0)]
        public PaymentVerificationWithExtraResponseBody Body;
        
        public PaymentVerificationWithExtraResponse() {
        }
        
        public PaymentVerificationWithExtraResponse(PaymentVerificationWithExtraResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class PaymentVerificationWithExtraResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public long RefID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ExtraDetail;
        
        public PaymentVerificationWithExtraResponseBody() {
        }
        
        public PaymentVerificationWithExtraResponseBody(int Status, long RefID, string ExtraDetail) {
            this.Status = Status;
            this.RefID = RefID;
            this.ExtraDetail = ExtraDetail;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUnverifiedTransactionsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUnverifiedTransactions", Namespace="http://zarinpal.com/", Order=0)]
        public GetUnverifiedTransactionsRequestBody Body;
        
        public GetUnverifiedTransactionsRequest() {
        }
        
        public GetUnverifiedTransactionsRequest(GetUnverifiedTransactionsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class GetUnverifiedTransactionsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        public GetUnverifiedTransactionsRequestBody() {
        }
        
        public GetUnverifiedTransactionsRequestBody(string MerchantID) {
            this.MerchantID = MerchantID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUnverifiedTransactionsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUnverifiedTransactionsResponse", Namespace="http://zarinpal.com/", Order=0)]
        public GetUnverifiedTransactionsResponseBody Body;
        
        public GetUnverifiedTransactionsResponse() {
        }
        
        public GetUnverifiedTransactionsResponse(GetUnverifiedTransactionsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class GetUnverifiedTransactionsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authorities;
        
        public GetUnverifiedTransactionsResponseBody() {
        }
        
        public GetUnverifiedTransactionsResponseBody(int Status, string Authorities) {
            this.Status = Status;
            this.Authorities = Authorities;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RefreshAuthorityRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RefreshAuthority", Namespace="http://zarinpal.com/", Order=0)]
        public RefreshAuthorityRequestBody Body;
        
        public RefreshAuthorityRequest() {
        }
        
        public RefreshAuthorityRequest(RefreshAuthorityRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class RefreshAuthorityRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MerchantID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Authority;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int ExpireIn;
        
        public RefreshAuthorityRequestBody() {
        }
        
        public RefreshAuthorityRequestBody(string MerchantID, string Authority, int ExpireIn) {
            this.MerchantID = MerchantID;
            this.Authority = Authority;
            this.ExpireIn = ExpireIn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RefreshAuthorityResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RefreshAuthorityResponse", Namespace="http://zarinpal.com/", Order=0)]
        public RefreshAuthorityResponseBody Body;
        
        public RefreshAuthorityResponse() {
        }
        
        public RefreshAuthorityResponse(RefreshAuthorityResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://zarinpal.com/")]
    public partial class RefreshAuthorityResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Status;
        
        public RefreshAuthorityResponseBody() {
        }
        
        public RefreshAuthorityResponseBody(int Status) {
            this.Status = Status;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PaymentGatewayImplementationServicePortTypeChannel : PaymentGatewayImplementationServicePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PaymentGatewayImplementationServicePortTypeClient : System.ServiceModel.ClientBase<PaymentGatewayImplementationServicePortType>, PaymentGatewayImplementationServicePortType {
        
        public PaymentGatewayImplementationServicePortTypeClient() {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PaymentGatewayImplementationServicePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PaymentRequestResponse PaymentGatewayImplementationServicePortType.PaymentRequest(PaymentRequestRequest request) {
            return base.Channel.PaymentRequest(request);
        }
        
        public int PaymentRequest(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL, out string Authority) {
            PaymentRequestRequest inValue = new PaymentRequestRequest();
            inValue.Body = new PaymentRequestRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            PaymentRequestResponse retVal = ((PaymentGatewayImplementationServicePortType)(this)).PaymentRequest(inValue);
            Authority = retVal.Body.Authority;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PaymentRequestResponse> PaymentGatewayImplementationServicePortType.PaymentRequestAsync(PaymentRequestRequest request) {
            return base.Channel.PaymentRequestAsync(request);
        }
        
        public System.Threading.Tasks.Task<PaymentRequestResponse> PaymentRequestAsync(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL) {
            PaymentRequestRequest inValue = new PaymentRequestRequest();
            inValue.Body = new PaymentRequestRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            return ((PaymentGatewayImplementationServicePortType)(this)).PaymentRequestAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PaymentRequestWithExtraResponse PaymentGatewayImplementationServicePortType.PaymentRequestWithExtra(PaymentRequestWithExtraRequest request) {
            return base.Channel.PaymentRequestWithExtra(request);
        }
        
        public int PaymentRequestWithExtra(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL, out string Authority) {
            PaymentRequestWithExtraRequest inValue = new PaymentRequestWithExtraRequest();
            inValue.Body = new PaymentRequestWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.AdditionalData = AdditionalData;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            PaymentRequestWithExtraResponse retVal = ((PaymentGatewayImplementationServicePortType)(this)).PaymentRequestWithExtra(inValue);
            Authority = retVal.Body.Authority;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PaymentRequestWithExtraResponse> PaymentGatewayImplementationServicePortType.PaymentRequestWithExtraAsync(PaymentRequestWithExtraRequest request) {
            return base.Channel.PaymentRequestWithExtraAsync(request);
        }
        
        public System.Threading.Tasks.Task<PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL) {
            PaymentRequestWithExtraRequest inValue = new PaymentRequestWithExtraRequest();
            inValue.Body = new PaymentRequestWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Amount = Amount;
            inValue.Body.Description = Description;
            inValue.Body.AdditionalData = AdditionalData;
            inValue.Body.Email = Email;
            inValue.Body.Mobile = Mobile;
            inValue.Body.CallbackURL = CallbackURL;
            return ((PaymentGatewayImplementationServicePortType)(this)).PaymentRequestWithExtraAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PaymentVerificationResponse PaymentGatewayImplementationServicePortType.PaymentVerification(PaymentVerificationRequest request) {
            return base.Channel.PaymentVerification(request);
        }
        
        public int PaymentVerification(string MerchantID, string Authority, int Amount, out long RefID) {
            PaymentVerificationRequest inValue = new PaymentVerificationRequest();
            inValue.Body = new PaymentVerificationRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            PaymentVerificationResponse retVal = ((PaymentGatewayImplementationServicePortType)(this)).PaymentVerification(inValue);
            RefID = retVal.Body.RefID;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PaymentVerificationResponse> PaymentGatewayImplementationServicePortType.PaymentVerificationAsync(PaymentVerificationRequest request) {
            return base.Channel.PaymentVerificationAsync(request);
        }
        
        public System.Threading.Tasks.Task<PaymentVerificationResponse> PaymentVerificationAsync(string MerchantID, string Authority, int Amount) {
            PaymentVerificationRequest inValue = new PaymentVerificationRequest();
            inValue.Body = new PaymentVerificationRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            return ((PaymentGatewayImplementationServicePortType)(this)).PaymentVerificationAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PaymentVerificationWithExtraResponse PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtra(PaymentVerificationWithExtraRequest request) {
            return base.Channel.PaymentVerificationWithExtra(request);
        }
        
        public int PaymentVerificationWithExtra(string MerchantID, string Authority, int Amount, out long RefID, out string ExtraDetail) {
            PaymentVerificationWithExtraRequest inValue = new PaymentVerificationWithExtraRequest();
            inValue.Body = new PaymentVerificationWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            PaymentVerificationWithExtraResponse retVal = ((PaymentGatewayImplementationServicePortType)(this)).PaymentVerificationWithExtra(inValue);
            RefID = retVal.Body.RefID;
            ExtraDetail = retVal.Body.ExtraDetail;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PaymentVerificationWithExtraResponse> PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtraAsync(PaymentVerificationWithExtraRequest request) {
            return base.Channel.PaymentVerificationWithExtraAsync(request);
        }
        
        public System.Threading.Tasks.Task<PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(string MerchantID, string Authority, int Amount) {
            PaymentVerificationWithExtraRequest inValue = new PaymentVerificationWithExtraRequest();
            inValue.Body = new PaymentVerificationWithExtraRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.Amount = Amount;
            return ((PaymentGatewayImplementationServicePortType)(this)).PaymentVerificationWithExtraAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GetUnverifiedTransactionsResponse PaymentGatewayImplementationServicePortType.GetUnverifiedTransactions(GetUnverifiedTransactionsRequest request) {
            return base.Channel.GetUnverifiedTransactions(request);
        }
        
        public int GetUnverifiedTransactions(string MerchantID, out string Authorities) {
            GetUnverifiedTransactionsRequest inValue = new GetUnverifiedTransactionsRequest();
            inValue.Body = new GetUnverifiedTransactionsRequestBody();
            inValue.Body.MerchantID = MerchantID;
            GetUnverifiedTransactionsResponse retVal = ((PaymentGatewayImplementationServicePortType)(this)).GetUnverifiedTransactions(inValue);
            Authorities = retVal.Body.Authorities;
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GetUnverifiedTransactionsResponse> PaymentGatewayImplementationServicePortType.GetUnverifiedTransactionsAsync(GetUnverifiedTransactionsRequest request) {
            return base.Channel.GetUnverifiedTransactionsAsync(request);
        }
        
        public System.Threading.Tasks.Task<GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(string MerchantID) {
            GetUnverifiedTransactionsRequest inValue = new GetUnverifiedTransactionsRequest();
            inValue.Body = new GetUnverifiedTransactionsRequestBody();
            inValue.Body.MerchantID = MerchantID;
            return ((PaymentGatewayImplementationServicePortType)(this)).GetUnverifiedTransactionsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RefreshAuthorityResponse PaymentGatewayImplementationServicePortType.RefreshAuthority(RefreshAuthorityRequest request) {
            return base.Channel.RefreshAuthority(request);
        }
        
        public int RefreshAuthority(string MerchantID, string Authority, int ExpireIn) {
            RefreshAuthorityRequest inValue = new RefreshAuthorityRequest();
            inValue.Body = new RefreshAuthorityRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.ExpireIn = ExpireIn;
            RefreshAuthorityResponse retVal = ((PaymentGatewayImplementationServicePortType)(this)).RefreshAuthority(inValue);
            return retVal.Body.Status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RefreshAuthorityResponse> PaymentGatewayImplementationServicePortType.RefreshAuthorityAsync(RefreshAuthorityRequest request) {
            return base.Channel.RefreshAuthorityAsync(request);
        }
        
        public System.Threading.Tasks.Task<RefreshAuthorityResponse> RefreshAuthorityAsync(string MerchantID, string Authority, int ExpireIn) {
            RefreshAuthorityRequest inValue = new RefreshAuthorityRequest();
            inValue.Body = new RefreshAuthorityRequestBody();
            inValue.Body.MerchantID = MerchantID;
            inValue.Body.Authority = Authority;
            inValue.Body.ExpireIn = ExpireIn;
            return ((PaymentGatewayImplementationServicePortType)(this)).RefreshAuthorityAsync(inValue);
        }
    }
}
