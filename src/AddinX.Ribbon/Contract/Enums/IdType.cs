namespace AddinX.Ribbon.Contract.Enums {
    public enum IdType {
        /// <summary>
        ///  Standard id for  a Ribbon element
        /// <example>
        /// <code>  <button id="myBtnId" label="myLabel" .../> </code>
        /// </example>
        /// </summary>
        id,

        /// <summary>
        ///  Microsoft internal Id for ribbons elements
        /// <example>
        /// <code>  <button idMso="FileSave" .../> </code>
        /// </example>
        /// </summary>
        idMso,


        /// <summary>
        ///  Associate the Id to a private name-space defined in the CustomUi
        /// <example>
        /// <code>  <button idQ="x:myBtnId" label="myLabel" .../> </code>
        /// </example>
        /// </summary>
        idQ
    }
}