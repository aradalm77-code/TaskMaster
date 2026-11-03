import { editProfileBtn } from './elements.js';
import { ShowProfile } from './ShowProfile.js';
import { RenderMessage } from './RenderMessage.js';

const ShowEditForm = () => {
    const form = `<form class="update-user-form">
    <div class="form-header">
        <div class="form-icon">
            <i class="fa-solid fa-user-pen"></i>
        </div>

        <div class="form-heading">
            <h2>Update Profile</h2>
            <p>Manage your personal information and account details.</p>
        </div>
    </div>

    <div class="form-divider"></div>

    <div class="form-fields">
        <div class="form-group">
            <label for="firstName">First Name</label>
            <input
                type="text"
                id="firstName"
                name="firstName"
                placeholder="Enter your first name"
                autocomplete="given-name"
            />
        </div>

        <div class="form-group">
            <label for="lastName">Last Name</label>
            <input
                type="text"
                id="lastName"
                name="lastName"
                placeholder="Enter your last name"
                autocomplete="family-name"
            />
        </div>

        <div class="form-group full-width">
            <label for="username">Username</label>
            <div class="input-wrapper">
                <i class="fa-solid fa-at input-icon"></i>
                <input
                    type="text"
                    id="username"
                    name="username"
                    placeholder="Enter your username"
                    autocomplete="username"
                />
            </div>
            <span class="field-hint">Your username is used to identify your account.</span>
        </div>

        <div class="form-group">
            <label for="password">New Password</label>
            <div class="input-wrapper">
                <i class="fa-solid fa-lock input-icon"></i>
                <input
                    type="password"
                    id="password"
                    name="password"
                    placeholder="Enter a new password"
                    autocomplete="new-password"
                />
            </div>
            <span class="field-hint">Leave empty to keep your current password.</span>
        </div>

        <div class="form-group">
            <label for="confirmPassword">Confirm New Password</label>
            <div class="input-wrapper">
                <i class="fa-solid fa-shield-halved input-icon"></i>
                <input
                    type="password"
                    id="confirmPassword"
                    name="confirmPassword"
                    placeholder="Confirm your new password"
                    autocomplete="new-password"
                />
            </div>
        </div>
    </div>

    <div class="form-footer">
        <span class="form-note">
            <i class="fa-solid fa-circle-info"></i>
            Make sure your information is correct.
        </span>

        <button type="submit" class="update-user-button">
            <i class="fa-solid fa-floppy-disk"></i>
            <span>Save Changes</span>
        </button>
    </div>
</form>`
    document.body.insertAdjacentHTML("beforeend", form);
}


editProfileBtn?.addEventListener("click", ShowEditForm);