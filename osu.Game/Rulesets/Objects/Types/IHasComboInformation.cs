﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Game.Skinning;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Objects.Types
{
    /// <summary>
    /// A HitObject that is part of a combo and has extended information about its position relative to other combo objects.
    /// </summary>
    public interface IHasComboInformation : IHasCombo
    {
        Bindable<int> IndexInCurrentComboBindable { get; }

        /// <summary>
        /// The offset of this hitobject in the current combo.
        /// </summary>
        int IndexInCurrentCombo { get; set; }

        Bindable<int> ComboIndexBindable { get; }

        /// <summary>
        /// The offset of this combo in relation to the beatmap.
        /// </summary>
        int ComboIndex { get; set; }

        /// <summary>
        /// Whether the HitObject starts a new combo.
        /// </summary>
        new bool NewCombo { get; set; }

        Bindable<bool> LastInComboBindable { get; }

        /// <summary>
        /// Whether this is the last object in the current combo.
        /// </summary>
        bool LastInCombo { get; set; }

        /// <summary>
        /// Retrieves the colour of the combo described by this <see cref="IHasComboInformation"/> object.
        /// </summary>
        /// <param name="skin">The skin to retrieve the combo colour from, if wanted.</param>
        Color4 GetComboColour(ISkin skin) => GetSkinComboColour(this, skin, ComboIndex);

        /// <summary>
        /// Retrieves the colour of the combo described by a given <see cref="IHasComboInformation"/> object from a given skin.
        /// </summary>
        /// <param name="combo">The combo information, should be <c>this</c>.</param>
        /// <param name="skin">The skin to retrieve the combo colour from.</param>
        /// <param name="comboIndex">The index to retrieve the combo colour with.</param>
        /// <returns></returns>
        protected static Color4 GetSkinComboColour(IHasComboInformation combo, ISkin skin, int comboIndex)
        {
            return skin.GetConfig<SkinComboColourLookup, Color4>(new SkinComboColourLookup(comboIndex, combo))?.Value ?? Color4.White;
        }
    }
}
