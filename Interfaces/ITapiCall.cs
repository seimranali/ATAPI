﻿// TapiCall.cs
//
// This is a part of the TAPI Applications Classes .NET library (ATAPI)
//
// Copyright (c) 2005-2018 JulMar Technology, Inc.
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS 
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;

namespace JulMarAtapi
{
    /// <summary>
    /// This class represents a single 1st party call in Tapi.
    /// </summary>
    public interface ITapiCall
	{
		/// <summary>
		/// Returns the <see cref="ITapiAddress"/> associated with the call.
		/// </summary>
		ITapiAddress Address { get; }

		/// <summary>
		/// Enables an application to get/set the application-specific field of the specified call's call-information record
		/// </summary>
		int AppSpecificData { get; set; }

		/// <summary>
		/// Value that specifies the current bearer mode of the call.
		/// </summary>
		BearerModes BearerMode { get; set; }

		/// <summary>
		/// Gets and sets the CallData associated with the call. Depending on the service provider implementation, the CallData member can be propagated to all 
		/// applications having handles to the call, including those on other machines (through the server), and can travel with the call when it is transferred.
		/// </summary>
		byte[] CallData { get; set; }

		/// <summary>
		/// Returns the called ID number
		/// </summary>
		string CalledId { get; }

		/// <summary>
		/// Returns the called ID name or empty string.
		/// </summary>
		string CalledName { get; }

		/// <summary>
		/// Returns the caller ID number
		/// </summary>
		string CallerId { get; }

		/// <summary>
		/// Returns the caller ID name or empty string
		/// </summary>
		string CallerName { get; }

		/// <summary>
		/// This returns the underlying HTCALL which you can use in your
		/// own interop scenarios to deal with custom methods or places
		/// which are not wrapped by ATAPI
		/// </summary>
		SafeHandle CallHandle { get; }

		/// <summary>
		/// Returns the call origin information
		/// </summary>
		CallOrigins CallOrigin { get; }

		/// <summary>
		/// Returns the call reason information
		/// </summary>
		CallReasons CallReason { get; }

		/// <summary>
		/// Returns the current call state for the call.
		/// </summary>
		CallState CallState { get; }

		/// <summary>
		/// Returns the connected ID number.
		/// </summary>
		string ConnectedId { get; }

		/// <summary>
		/// Returns the connected ID name or empty string.
		/// </summary>
		string ConnectedName { get; }

		/// <summary>
		/// Rate of the call data stream, in bits per second (bps).
		/// </summary>
		int DataRate { get; set; }

		/// <summary>
		/// Returns the Device Specific data for this call
		/// </summary>
		byte[] DeviceSpecificData { get; }

		/// <summary>
		/// Duration of a comma in the dialable address, in milliseconds. 
		/// </summary>
		int DialPause { get; set; }

		/// <summary>
		/// Interdigit time period between successive digits, in milliseconds.
		/// </summary>
		int DialSpeed { get; set; }

		/// <summary>
		/// Duration of a digit, in milliseconds. 
		/// </summary>
		int DigitDuration { get; set; }

		/// <summary>
		/// Returns the <see cref="CallFeatureSet"/> representing the available features for the call.
		/// </summary>
		CallFeatureSet Features { get; }

		/// <summary>
		/// Gets or sets a unique identifier to the call.
		/// This unique identifier is generated by the library to identify each call
		/// </summary>
		Guid Guid { get; set; }

		/// <summary>
		/// In some telephony environments, the switch, or service provider can assign a unique identifier to each call. 
		/// This enables the call to be tracked across transfers, forwards, or other events. The domain of these call identifiers 
		/// and their scope is service provider-defined. The dwCallID member makes this unique identifier available to the applications. 
		/// </summary>
		int Id { get; }

		/// <summary>
		/// Returns the time/date that the last status change occurred.
		/// </summary>
		DateTime LastEventTime { get; }

		/// <summary>
		/// Returns the <see cref="TapiLine"/> associated with the call.
		/// </summary>
		ITapiLine Line { get; }

		/// <summary>
		/// This turns media detection on and off.  It is enabled by default, but can be turned off to avoid computational overhead when 
		/// media detection is not required.
		/// </summary>
		bool MediaDetection { get; set; }

		/// <summary>
		/// Value that specifies the media mode of the data stream currently on the call. This is the media mode determined by the owner of the call.
		/// </summary>
		MediaModes MediaMode { get; }

		/// <summary>
		/// Retrieve or set the application's privilege to this call
		/// </summary>
		Privilege Privilege { get; set; }

		/// <summary>
		/// Returns the redirecting ID number.
		/// </summary>
		string RedirectingId { get; }

		/// <summary>
		/// Returns the redirecting ID name or empty string.
		/// </summary>
		string RedirectingName { get; }

		/// <summary>
		/// Returns the redirection ID number
		/// </summary>
		string RedirectionId { get; }

		/// <summary>
		/// Returns the redirection ID name or empty string.
		/// </summary>
		string RedirectionName { get; }

		/// <summary>
		/// Returns any related numeric call id
		/// </summary>
		int RelatedId { get; }

		/// <summary>
		/// This associates an arbitrary object with the call
		/// </summary>
		object Tag { get; set; }

		/// <summary>
		/// Number of the trunk over which the call is routed. This will be 0xffffffff if unknown.
		/// </summary>
		int TrunkId { get; }

		/// <summary>
		/// This retrieves the user-user information which can be passed along the wire on some telephony systems.
		/// It returns an empty string if no UUI exists for this call.  You can use <see cref="TapiCall.SendUserUserInfo"/> to send data.
		/// </summary>
		string UserUserInfo { get; }

		/// <summary>
		/// Maximum amount of time to wait for a dial tone when a 'W' is used in the dialable address, in milliseconds. 
		/// </summary>
		int WaitForDialtoneDuration { get; set; }

		/// <summary>
		/// Maximum amount of time to wait for a dial tone when a 'W' is used in the dialable address, in milliseconds. 
		/// </summary>
		void Accept();

		/// <summary>
		/// This function accepts the specified offered call. It can optionally send the specified user-user information to the calling party.
		/// </summary>
		/// <param name="uuInfo">Buffer containing user-user information to be sent to the remote party as part of the call accept or null if no user-user information is to be sent.</param>
		void Accept(byte[] uuInfo);

		/// <summary>
		/// This adds the call to the existing conference.  The current call must be a
		/// conference call and in the proper call state.
		/// </summary>
		/// <param name="callToAdd">Call to add to this conference</param>
		void AddToConference(TapiCall callToAdd);

		/// <summary>
		/// This function answers the specified offering call. 
		/// </summary>
		void Answer();

		/// <summary>
		/// This function answers the specified offering call. 
		/// </summary>
		/// <param name="uuInfo">Buffer containing user-user information to be sent to the remote party as part of the call answer or null if no user-user information is to be sent.</param>
		void Answer(byte[] uuInfo);

		/// <summary>
		/// This function accepts the specified offered call. It can optionally send the specified user-user information to the calling party.
		/// </summary>
		/// <param name="acb">AsyncCallback method</param>
		/// <param name="state">State data</param>
		IAsyncResult BeginAccept(AsyncCallback acb, object state);

		/// <summary>
		/// This function accepts the specified offered call. It can optionally send the specified user-user information to the calling party.
		/// </summary>
		/// <param name="uuInfo">Buffer containing user-user information to be sent to the remote party as part of the call accept or null if no user-user information is to be sent.</param>
		/// <param name="acb">AsyncCallback method</param>
		/// <param name="state">State data</param>
		IAsyncResult BeginAccept(byte[] uuInfo, AsyncCallback acb, object state);

		/// <summary>
		/// This adds the call to the existing conference.  The current call must be a
		/// conference call and in the proper call state.
		/// </summary>
		/// <param name="callToAdd">Call to add to this conference</param>
		/// <param name="acb">Callback function</param>
		/// <param name="state">State parameter</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginAddToConference(TapiCall callToAdd, AsyncCallback acb, object state);

		/// <summary>
		/// This function answers the specified offering call. 
		/// </summary>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginAnswer(AsyncCallback acb, object state);

		/// <summary>
		/// This function answers the specified offering call. 
		/// </summary>
		/// <param name="uuInfo">Buffer containing user-user information to be sent to the remote party as part of the call answer or null if no user-user information is to be sent.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginAnswer(byte[] uuInfo, AsyncCallback acb, object state);

		/// <summary>
		/// Performs a single-step (blind) transfer of the call to a target number.
		/// </summary>
		/// <param name="destAddress">Destinationa address</param>
		/// <param name="countryCode">Country code or zero for default.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginBlindTransfer(string destAddress, int countryCode, AsyncCallback acb, object state);

		/// <summary>
		/// Specifies how a call that could not be connected normally should be completed instead. The network or switch may not be able to 
		/// complete a call because network resources are busy or the remote station is busy or doesn't answer. The application can request that 
		/// the call be completed in one of a number of ways.
		/// </summary>
		/// <param name="mode">Completion mode</param>
		/// <param name="messageId">Message Id if sending message</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginCompleteCall(CallCompletionMode mode, int messageId, AsyncCallback acb, object state);

		/// <summary>
		/// This method executes device-specific functionality on the underlying service provider.
		/// </summary>
		/// <param name="inData">Input data</param>
		/// <param name="acb">Callback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginDeviceSpecific(byte[] inData, AsyncCallback acb, object state);

		/// <summary>
		/// Dials digits on the call
		/// </summary>
		/// <param name="destAddress">Destination address</param>
		/// <param name="countryCode">Country code or zero for default.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginDial(string destAddress, int countryCode, AsyncCallback acb, object state);

		/// <summary>
		/// Drops the active call
		/// </summary>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginDrop(AsyncCallback acb, object state);

		/// <summary>
		/// Drops the active call
		/// </summary>
		/// <param name="uuInfo">Buffer containing user-user information to be sent to the remote party as part of the call drop or null if no user-user information is to be sent.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginDrop(byte[] uuInfo, AsyncCallback acb, object state);

		/// <summary>
		/// Gathers digits from the call until an end condition is met.
		/// </summary>
		/// <param name="digitModes">Digit mode(s) to be monitored</param>
		/// <param name="maxDigits">Number of digits to be collected</param>
		/// <param name="termDigits">List of termination digits. If one of the digits in the string is detected, that termination digit is appended to the buffer and digit collection is terminated</param>
		/// <param name="firstDigitTimeout">Time duration in milliseconds in which the first digit is expected</param>
		/// <param name="interDigitTimeout">Maximum time duration in milliseconds between consecutive digits.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">Object state</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginGatherDigits(DigitModes digitModes, int maxDigits, string termDigits, int firstDigitTimeout, int interDigitTimeout, AsyncCallback acb, object state);

		/// <summary>
		/// This method generates DTMF digits on the call.
		/// </summary>
		/// <param name="digitMode">Format to be used for signaling these digits.</param>
		/// <param name="digits">Buffer of digits to be generated.</param>
		/// <param name="duration">Both the duration in milliseconds of DTMF digits and pulse and DTMF inter-digit spacing. A value of 0 uses a default value.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">Object state</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginGenerateDigits(DigitModes digitMode, string digits, int duration, AsyncCallback acb, object state);

		/// <summary>
		/// This method generates the specified inband tone over the specified call.
		/// </summary>
		/// <param name="tones">Array of custom tones to generate</param>
		/// <param name="duration">Length of tone generation</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">Object state</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginGenerateTone(CustomTone[] tones, int duration, AsyncCallback acb, object state);

		/// <summary>
		/// This method generates the specified inband tone over the specified call.
		/// </summary>
		/// <param name="toneMode">Format to be used for tone.</param>
		/// <param name="duration">Duration in milliseconds during which the tone should be sustained. A value of 0 for dwDuration uses a default duration for the specified tone.</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">Object state</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginGenerateTone(ToneModes toneMode, int duration, AsyncCallback acb, object state);

		/// <summary>
		/// Places the call on hold
		/// </summary>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAscyncResult</returns>
		IAsyncResult BeginHold(AsyncCallback acb, object state);

		/// <summary>
		/// Enables the unbuffered detection of digits received on the call. Each time a digit of the specified digit mode is detected, a 
		/// callback event is raised in the application indicating which digit has been detected.
		/// </summary>
		/// <param name="modes">DigitModes to detect</param>
		/// <param name="acb">Callback to use</param>
		void BeginMonitoringDigits(DigitModes modes, EventHandler<DigitDetectedEventArgs> acb);

		/// <summary>
		/// Enables the detection of inband tones on the call. Each time a specified tone is detected, a message is sent to the application.
		/// </summary>
		/// <param name="tones">List of tones to watch for</param>
		/// <param name="acb">Callback</param>
		void BeginMonitoringTones(MonitorTone[] tones, EventHandler<ToneDetectedEventArgs> acb);

		/// <summary>
		/// Parks the call at a non-directed address
		/// </summary>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginPark(AsyncCallback acb, object state);

		/// <summary>
		/// Parks the call at the directed address
		/// </summary>
		/// <param name="address">Number to park the call at</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginPark(string address, AsyncCallback acb, object state);

		/// <summary>
		/// Redirects the specified offering call to the specified destination address
		/// </summary>
		/// <param name="destAddress">Address to redirect to</param>
		/// <param name="countryCode">Country code (zero for default)</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginRedirect(string destAddress, int countryCode, AsyncCallback acb, object state);

		/// <summary>
		/// This removes a call from the existing conference.  The current call must be a
		/// conference call and in the proper call state.
		/// </summary>
		/// <param name="callToRemove">Call to remove from this conference</param>
		/// <param name="acb">Callback function</param>
		/// <param name="state">State parameter</param>
		/// <returns>IAsyncResult</returns>
		IAsyncResult BeginRemoveToConference(TapiCall callToRemove, AsyncCallback acb, object state);

		/// <summary>
		/// Secures the call from any interruptions or interference that can affect the call's media stream.
		/// </summary>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAscyncResult</returns>
		IAsyncResult BeginSecureCall(AsyncCallback acb, object state);

		/// <summary>
		/// Swaps two calls from active to on hold
		/// </summary>
		/// <param name="otherCall">Call to swap with</param>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAscyncResult</returns>
		IAsyncResult BeginSwapHold(TapiCall otherCall, AsyncCallback acb, object state);

		/// <summary>
		/// Retrieves a call that is holding
		/// </summary>
		/// <param name="acb">AsyncCallback</param>
		/// <param name="state">State data</param>
		/// <returns>IAscyncResult</returns>
		IAsyncResult BeginUnhold(AsyncCallback acb, object state);

		/// <summary>
		/// Performs a single-step (blind) transfer of the call to a target number.
		/// </summary>
		/// <param name="destAddress">Destinationa address</param>
		/// <param name="countryCode">Country code or zero for default.</param>
		void BlindTransfer(string destAddress, int countryCode);

		/// <summary>
		/// This method cancels a previously request digit gather.  The <see cref="TapiCall.EndGatherDigits"/> may then be called.
		/// </summary>
		void CancelGatherDigits();

		/// <summary>
		/// This method cancels a digit generation request.
		/// </summary>
		void CancelGenerateDigits();

		/// <summary>
		/// This method cancels a tone generation request.
		/// </summary>
		void CancelGenerateTone();

		/// <summary>
		/// This cancels any digit monitor enabled on this call.
		/// </summary>
		void CancelMonitoringDigits();

		/// <summary>
		/// This is used to cancel a tone monitor request.
		/// </summary>
		void CancelMonitoringTones();

		/// <summary>
		/// This function informs the service provider that the application has processed the user-user information contained in the call, and that subsequently
		/// received user-user information can now be written into that structure. 
		/// </summary>
		void ClearUserUserInfo();

		/// <summary>
		/// Specifies how a call that could not be connected normally should be completed instead. The network or switch may not be able to 
		/// complete a call because network resources are busy or the remote station is busy or doesn't answer. The application can request that 
		/// the call be completed in one of a number of ways.
		/// </summary>
		/// <param name="mode">Completion mode</param>
		/// <param name="messageIndex">Message Id if sending message - this is the index of the <see cref="AddressCapabilities.AvailableCallCompletionMessages"/> entry.</param>
		int CompleteCall(CallCompletionMode mode, int messageIndex);

		/// <summary>
		/// This function completes the transfer of the specified call to the party connected in the consultation call.
		/// </summary>
		/// <param name="consultationCall">Consultation call to transfer to</param>
		void CompleteTransfer(TapiCall consultationCall);

		/// <summary>
		/// This function completes a transfer by conferencing the two parties together.
		/// </summary>
		/// <param name="consultationCall">The second call to conference in with this one.</param>
		/// <returns>Conference call</returns>
		TapiCall CompleteTransferToConference(TapiCall consultationCall);

		/// <summary>
		/// This method executes device-specific functionality on the underlying service provider.
		/// </summary>
		/// <param name="inData">Input data</param>
		/// <returns>Output data</returns>
		byte[] DeviceSpecific(byte[] inData);

		/// <summary>
		/// Dials digits on the call
		/// </summary>
		/// <param name="destAddress">Destination address</param>
		/// <param name="countryCode">Country code or zero for default.</param>
		void Dial(string destAddress, int countryCode);

		/// <summary>
		/// Drops the active call
		/// </summary>
		void Drop();

		/// <summary>
		/// Drops the active call
		/// </summary>
		/// <param name="uuInfo">Buffer containing user-user information to be sent to the remote party as part of the call drop or null if no user-user information is to be sent.</param>
		void Drop(byte[] uuInfo);

		/// <summary>
		/// This retrieves the results of a previously issued <seealso cref="TapiCall.BeginAccept(byte[],AsyncCallback,object)"/> method.
		/// </summary>
		/// <param name="ar">IAsyncResult from the BeginAccept call.</param>
		void EndAccept(IAsyncResult ar);

		/// <summary>
		/// This ends an asynchronous AddToConference.
		/// </summary>
		/// <param name="ar">Pending IAsyncResult request</param>
		void EndAddToConference(IAsyncResult ar);

		/// <summary>
		/// Harvests the results from a previously issued <seealso cref="TapiCall.BeginAnswer(AsyncCallback, object)"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginAnswer</param>
		void EndAnswer(IAsyncResult ar);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginBlindTransfer"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginBlindTransfer</param>
		void EndBlindTransfer(IAsyncResult ar);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginCompleteCall"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginCompleteCall</param>
		/// <returns>Completion Id</returns>
		int EndCompleteCall(IAsyncResult ar);

		/// <summary>
		/// This method harvests the results from a <see cref="TapiAddress.BeginDeviceSpecific(byte[], AsyncCallback, object)"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginDeviceSpecific</param>
		/// <returns>Output data</returns>
		byte[] EndDeviceSpecific(IAsyncResult ar);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginDial"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginDial</param>
		void EndDial(IAsyncResult ar);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginDrop(AsyncCallback, object)"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult</param>
		void EndDrop(IAsyncResult ar);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginGatherDigits"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginGatherDigits</param>
		/// <param name="digits">Buffer to return digits</param>
		/// <returns>Completion reason</returns>
		DigitGatherComplete EndGatherDigits(IAsyncResult ar, out string digits);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginGenerateDigits"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginGenerateDigits</param>
		/// <returns>true/false success</returns>
		bool EndGenerateDigits(IAsyncResult ar);

		/// <summary>
		/// Harvests the results of a previously issued <see cref="TapiCall.BeginGenerateTone(ToneModes, int, AsyncCallback, object)"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginGenerateTone</param>
		/// <returns>true/false success</returns>
		bool EndGenerateTone(IAsyncResult ar);

		/// <summary>
		/// Retrieves the final result from a <see cref="TapiCall.BeginHold"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginHold</param>
		void EndHold(IAsyncResult ar);

		/// <summary>
		/// Retrieves the result of a <see cref="TapiCall.BeginPark(AsyncCallback, object)"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginPark</param>
		/// <returns>Non-directed park address if available</returns>
		string EndPark(IAsyncResult ar);

		/// <summary>
		/// Harvests the results from a call to <see cref="TapiCall.BeginRedirect"/>.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginRedirect</param>
		void EndRedirect(IAsyncResult ar);

		/// <summary>
		/// This ends an asynchronous RemoveFromConference.
		/// </summary>
		/// <param name="ar">Pending IAsyncResult request</param>
		void EndRemoveFromConference(IAsyncResult ar);

		/// <summary>
		/// Retrieves the final result from a <see cref="TapiCall.BeginSecureCall"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginHold</param>
		void EndSecureCall(IAsyncResult ar);

		/// <summary>
		/// Retrieves the final result from a <see cref="TapiCall.BeginSwapHold"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginSwapHold</param>
		void EndSwapHold(IAsyncResult ar);

		/// <summary>
		/// Retrieves the final result from a <see cref="TapiCall.BeginUnhold"/> call.
		/// </summary>
		/// <param name="ar">IAsyncResult from BeginUnhold</param>
		void EndUnhold(IAsyncResult ar);

		/// <summary>
		/// Gathers digits from the call until an end condition is met.
		/// </summary>
		/// <param name="digitModes">Digit mode(s) to be monitored</param>
		/// <param name="maxDigits">Number of digits to be collected</param>
		/// <param name="termDigits">List of termination digits. If one of the digits in the string is detected, that termination digit is appended to the buffer and digit collection is terminated</param>
		/// <param name="firstDigitTimeout">Time duration in milliseconds in which the first digit is expected</param>
		/// <param name="interDigitTimeout">Maximum time duration in milliseconds between consecutive digits.</param>
		/// <param name="digits">Buffer to return digits</param>
		/// <returns>Completion reason</returns>
		DigitGatherComplete GatherDigits(DigitModes digitModes, int maxDigits, string termDigits, int firstDigitTimeout, int interDigitTimeout, out string digits);

		/// <summary>
		/// This method generates DTMF digits on the call.
		/// </summary>
		/// <param name="digitMode">Format to be used for signaling these digits.</param>
		/// <param name="digits">Buffer of digits to be generated.</param>
		/// <param name="duration">Both the duration in milliseconds of DTMF digits and pulse and DTMF inter-digit spacing. A value of 0 uses a default value.</param>
		/// <returns>true/false</returns>
		bool GenerateDigits(DigitModes digitMode, string digits, int duration);

		/// <summary>
		/// This method generates the specified custom tone inband over the specified call.
		/// </summary>
		/// <param name="tones">Array of custom tones to generate</param>
		/// <param name="duration">Duration of tone generation</param>
		/// <returns>True/False</returns>
		bool GenerateTone(CustomTone[] tones, int duration);

		/// <summary>
		/// This method generates the specified inband tone over the specified call.
		/// </summary>
		/// <param name="toneMode">Format to be used for tone.</param>
		/// <param name="duration">Duration in milliseconds during which the tone should be sustained. A value of 0 for dwDuration uses a default duration for the specified tone.</param>
		/// <returns>true/false</returns>
		bool GenerateTone(ToneModes toneMode, int duration);

		/// <summary>
		/// This returns the name of the COMM device this call is running on
		/// </summary>
		/// <returns>String representing COM port or null</returns>
		string GetCommDevice();

		/// <summary>
		/// This returns the underlying COMM handle for the given call.  This is primarily for modem-style lines.
		/// </summary>
		/// <returns>SafeHandle representing COMM handle or null</returns>
		SafeFileHandle GetCommHandle();

		/// <summary>
		/// This method returns a FileStream to represent our I/O channel
		/// with the COMM port.  It is always in asynch mode.
		/// </summary>
		/// <returns>FileStream object</returns>
		FileStream GetCommStream();

		/// <summary>
		/// Returns a device ID handle from an identifier.
		/// </summary>
		/// <param name="identifier">Identifier to lookup</param>
		/// <returns>Handle or null</returns>
		int? GetDeviceID(string identifier);

		/// <summary>
		/// This returns a device identifier for the specified device class associated with the call
		/// </summary>
		/// <param name="deviceClass">Device Class</param>
		/// <returns>string or byte[]</returns>
		object GetExternalDeviceInfo(string deviceClass);

		/// <summary>
		/// Returns the device id for the MIDI input device.  This identifier may be passed to "midiInOpen" to get a HMIDI handle.
		/// </summary>
		/// <returns>MIDI Device identifier</returns>
		int? GetMidiInDeviceID();

		/// <summary>
		/// Returns the device id for the MIDI output device.  This identifier may be passed to "midiOutOpen" to get a HMIDI handle.
		/// </summary>
		/// <returns>MIDI Device identifier</returns>
		int? GetMidiOutDeviceID();

		/// <summary>
		/// This returns the list of related conference call parties that are part of the same conference call as this call. 
		/// The specified call is either a conference call or a participant call in a conference call. 
		/// New handles are generated for those calls for which the application does not already have handles, 
		/// and the application is granted monitor privilege to those calls. 
		/// </summary>
		/// <returns></returns>
		TapiCall[] GetRelatedConferenceCalls();

		/// <summary>
		/// Returns the device id for the wave input device.  This identifier may be passed to "waveInOpen" to get a HWAVE handle.
		/// </summary>
		/// <returns>Wave Device identifier</returns>
		int? GetWaveInDeviceID();

		/// <summary>
		/// Returns the device id for the wave output device.  This identifier may be passed to "waveOutOpen" to get a HWAVE handle.
		/// </summary>
		/// <returns>Wave Device identifier</returns>
		int? GetWaveOutDeviceID();

		/// <summary>
		/// Places the call on hold
		/// </summary>
		void Hold();

		/// <summary>
		/// Parks the call at a non-directed address and returns where it was parked.
		/// </summary>
		/// <returns>Park address</returns>
		string Park();

		/// <summary>
		/// Parks the call at the directed address
		/// </summary>
		/// <param name="address">Number to park the call at</param>
		void Park(string address);

		/// <summary>
		/// This function gets a consultation call from a conference in order to add a new party to the conference
		/// </summary>
		/// <param name="mcp">Optional call parameters for the consultation call.  You can perform an auto conference by supplying a TargetAddress.</param>
		/// <returns>Consultation call</returns>
		TapiCall PrepareAddToConference(MakeCallParams mcp);

		/// <summary>
		/// Redirects the specified offering call to the specified destination address
		/// </summary>
		/// <param name="destAddress">Address to redirect to</param>
		/// <param name="countryCode">Country code (zero for default)</param>
		void Redirect(string destAddress, int countryCode);

		/// <summary>
		/// This removes a call from the existing conference.  The current call must be a
		/// conference call and in the proper call state.
		/// </summary>
		/// <param name="callToRemove">Call to remove from this conference</param>
		void RemoveFromConference(TapiCall callToRemove);

		/// <summary>
		/// Secures the call from any interruptions or interference that can affect the call's media stream.
		/// </summary>
		void SecureCall();

		/// <summary>
		/// This method sends user-user information to the remote party on the specified call.
		/// </summary>
		/// <param name="message">Message to send</param>
		/// <returns>true/false success</returns>
		bool SendUserUserInfo(string message);

		/// <summary>
		/// This method sets the sounds a party on a call that is unanswered or on hold hears.
		/// </summary>
		/// <param name="ct">Designated call treatment type</param>
		/// <returns></returns>
		bool SetCallTreatment(CallTreatment ct);

		/// <summary>
		/// This method is used to establish a conference call
		/// </summary>
		/// <param name="conferenceCount"># of parties anticipated the conference</param>
		/// <param name="mcp">Call parameters for created consultation call</param>
		/// <param name="consultCall">Returning consultation call</param>
		/// <returns>Conference call</returns>
		TapiCall SetupConference(int conferenceCount, MakeCallParams mcp, out TapiCall consultCall);

		/// <summary>
		///  This function initiates a transfer of the call through the use of a consultation call on which the party can be dialed that can 
		/// become the destination of the transfer. The application acquires owner privilege to the returned call.
		/// </summary>
		/// <param name="param">Optional call parameters for the returned consultation call.  You can perform a one-step transfer by supplying a TargetAddress</param>
		/// <returns>Consultation call</returns>
		TapiCall SetupTransfer(MakeCallParams param);

		/// <summary>
		/// Swaps two calls from active to on hold
		/// </summary>
		void SwapHold(TapiCall otherCall);

		/// <summary>
		/// Retrieves a call that is holding
		/// </summary>
		void Unhold();

        /// <summary>
		/// IDisposable.Dispose implementation
		/// </summary>
        void Dispose();


    }
}
